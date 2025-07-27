using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Models;

namespace ApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : ControllerBase
{
    private static readonly List<Sale> _sales = new();

    [HttpPost]
    public ActionResult<Sale> Create(Sale sale)
    {
        _sales.Add(sale);
        return CreatedAtAction(nameof(Create), new { id = sale.Id }, sale);
    }
}
