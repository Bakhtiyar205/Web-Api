using E_Commerce.Application.Repositories.CustomerRepository;
using E_Commerce.Application.Repositories.OrderRepository;
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

    private readonly IOrderReadRepository _orderReadRepository;
    private readonly IOrderWriteRepository _orderWriteRepository;

    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;

    public ProductController(IProductReadRepository productReadRepository,
                             IProductWriteRepository productWriteRepository,
                             IOrderReadRepository orderReadRepository,
                             IOrderWriteRepository orderWriteRepository,
                             ICustomerWriteRepository customerWriteRepository,
                             ICustomerReadRepository customerReadRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _orderReadRepository = orderReadRepository;
        _orderWriteRepository = orderWriteRepository;
        _customerWriteRepository = customerWriteRepository;
        _customerReadRepository = customerReadRepository;
    }
    // GET
    [HttpGet]
    public async Task Gwt()
    {

    }

    [HttpGet("id")]
    public async Task<Product> FindId(string id)
    {
       return await _productReadRepository.GetByIdAsync(id);
    }
}