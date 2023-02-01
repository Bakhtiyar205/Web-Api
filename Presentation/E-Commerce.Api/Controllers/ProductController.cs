using E_Commerce.Application.Repositories.ProductRepository;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task Index()
    {
        List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Product",
                Stock = 100,
                Price = 12,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Product2",
                Stock = 100,
                Price = 12,
            }
        };
       await _productWriteRepository.AddRangeAsync(products);
       await _productWriteRepository.SaveAsync();
    }

    [HttpGet("id")]
    public async Task<Product> FindId(string id)
    {
       return await _productReadRepository.GetByIdAsync(id);
    }
}