using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.Repositories;

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _personRepo;
    public ProductController(ILogger<ProductController> logger, IProductRepository personRepo) {
        _logger = logger;
        _personRepo = personRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts() {
        try {
            return Ok("Hello Dev!");
        }
        catch (Exception ex) {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }}
}