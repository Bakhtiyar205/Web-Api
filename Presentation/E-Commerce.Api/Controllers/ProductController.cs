
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

    public ProductController(IProductReadRepository productReadRepository,
                             IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
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
    
}