using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Models;

namespace ApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InventoryController : ControllerBase
{
    private static readonly Dictionary<int, int> _inventory = new();

    [HttpPost]
    public IActionResult Adjust(InventoryUpdate update)
    {
        _inventory.TryGetValue(update.ProductId, out int qty);
        _inventory[update.ProductId] = qty + update.QuantityChange;
        return Ok(new { ProductId = update.ProductId, Quantity = _inventory[update.ProductId] });
    }
}
