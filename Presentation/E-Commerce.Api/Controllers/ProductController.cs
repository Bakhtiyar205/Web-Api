
using System.Net;
using System.Threading.Tasks;
using E_Commerce.Application.Repositories.CustomerRepository;
using E_Commerce.Application.Repositories.OrderRepository;
using E_Commerce.Application.Repositories.ProductRepository;
using E_Commerce.Application.RequestParameters;
using E_Commerce.Application.ViewModels.Products;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IProductReadRepository productReadRepository,
                             IProductWriteRepository productWriteRepository,
                             IWebHostEnvironment webHostEnvironment)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _webHostEnvironment = webHostEnvironment;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]Pagination pagination)
    {
        var totalCount = _productReadRepository.GetAll().Count();
        var products = _productReadRepository.GetAll(false)
            .Skip(pagination.Page * pagination.Size)
            .Take(pagination.Size).Select(p => new
        {
            p.Id,
            p.Name,
            p.Stock,
            p.Price,
            p.CreatedDate,
            p.UpdateDate
        });
        return Ok(new
        {
            totalCount,
            products
        });
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(string id)
    {
       return Ok(await _productReadRepository.GetByIdAsync(id,false));
    }

    [HttpPost]
    public async Task<IActionResult> Post(VmProductCreate product)
    {
        await _productWriteRepository.AddAsync(new()
        {
            Name = product.Name,
            Stock = product.Stock,
            Price = product.Price
        });
        await _productWriteRepository.SaveAsync();
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Put(VmProductUpdate vmPRoduct)
    {
        Product product = await _productReadRepository.GetByIdAsync(vmPRoduct.Id);
        product.Stock = vmPRoduct.Stock;
        product.Name = vmPRoduct.Name;
        product.Price = vmPRoduct.Price;

        await _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _productWriteRepository.Remove(id);
        await _productWriteRepository.SaveAsync();
        return Ok(new
        {
            message = "Product is deleted"
        });
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload()
    {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product");

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        
        Random r = new();
        foreach (IFormFile file in Request.Form.Files)
        {
            string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

            using FileStream fileStream = new
               (fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
        }

        return Ok();
    } 
    
}