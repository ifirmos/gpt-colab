using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Models;

namespace ApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> _products = new();

    [HttpGet]
    public IEnumerable<Product> Get() => _products;

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        _products.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
}
