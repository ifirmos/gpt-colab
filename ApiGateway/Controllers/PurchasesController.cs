using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Models;

namespace ApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PurchasesController : ControllerBase
{
    private static readonly List<Purchase> _purchases = new();

    [HttpPost]
    public ActionResult<Purchase> Register(Purchase purchase)
    {
        _purchases.Add(purchase);
        return CreatedAtAction(nameof(Register), new { id = purchase.Id }, purchase);
    }
}
