namespace StockCartApi;

using Microsoft.AspNetCore.Mvc;
using StockCartApi.Models;
using StockCartApi.Data;
[ApiController]
[Route("api/[controller]")]
public class ShopController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShopController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public IActionResult GetProducts()
    {
        var products = _context.Products.ToList();
        return Ok(products);
    }

  [HttpPost("products")]
public IActionResult UpdateProduct([FromBody] List<Product> products)
{
    foreach (var product in products)
    {
        var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct == null)
        {
            return NotFound(new { message = $"Product {product.Id} not found." });
        }

        if (product.Quantity > existingProduct.Stock)
        {
            return BadRequest(new { message = $"Not enough stock for Product {product.Id}." });
        }

        existingProduct.Stock -= product.Quantity;
    }

    _context.SaveChanges();

    return Ok(new { message = "Products updated successfully." });
}


    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }

}
