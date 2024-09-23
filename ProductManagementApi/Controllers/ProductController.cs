using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.Models;
using ProductManagementApi.Repositories;

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepo;
    public ProductController(ILogger<ProductController> logger, IProductRepository productRepo) {
        _logger = logger;
        _productRepo = productRepo;
    }

        [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product) {
        try {
            var createdProduct = await _productRepo.AddProductAsync(product);
            return CreatedAtAction(nameof(CreateProduct), createdProduct);
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts() {
        try {
            var products = await _productRepo.GetAllProductsAsync();
            return Ok(products);
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id) {
        try {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null) {
                return NotFound(new {
                    statusCode = 404,
                    message = "Produto nâo encontrado"
                });
            }
            return Ok(product);
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(Product productUpdated) {
        try {
            var product = await _productRepo.GetProductByIdAsync(productUpdated.Id);
            if (product == null) {
                return NotFound(new {
                    statusCode = 404,
                    message = "Produto nâo encontrado"
                });
            }
            await _productRepo.UpdateProductAsync(productUpdated);
            return NoContent();
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id) {
        try {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null) {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Produto nâo encontrado"
                });
            }
            await _productRepo.DeleteProductAsync(id);
            return NoContent();
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                statusCode = 500,
                message = ex.Message
            });
        }
    }
}}