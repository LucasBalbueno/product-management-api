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

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <remarks>
    /// O método POST cria um novo produto no banco de dados. O objeto produto deve ser passado no corpo da requisição.
    /// Exemplo de objeto produto:
    /// { "id": 1, "name": "NameExample", "price": 10, "quantity": 1 }
    /// </remarks>
    /// <param name="product">Objeto produto com suas informações de criação</param>
    /// <returns>Retorna um objeto de product</returns>
    /// <response code="201">Sucesso!</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Obter todos os produtos presente no Banco de Dados
    /// </summary>
    /// <remarks>
    /// Esse método GET retorna todos os produtos presentes no banco de dados. Não é necessário passar nenhum parâmetro.
    /// </remarks>
    /// <returns>Retorna toda a coleção de produtos atual</returns>
    /// <response code="200">Sucesso!</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Obter um produto específico
    /// </summary>
    /// <remarks>
    /// Esse método GET retorna um produto específico baseado no ID passado como parâmetro.
    /// </remarks>
    /// <param name="id">Identificador (ID) do produto a ser lido</param>
    /// <returns>Retorna um produto específico baseado no ID passado como parâmetro</returns>
    /// <response code="200">Sucesso!</response>
    /// <response code="404">Produto não encontrado</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Atualiza um produto específico
    /// </summary>
    /// <remarks>
    /// O método PUT atualiza um produto específico no banco de dados. O objeto produto com suas informações de atualização deve ser passado no corpo da requisição, inclusive o ID do produto a ser atualizado.
    /// Exemplo de objeto produto:
    /// { "id": 1, "name": "NameAtualizado", "price": 50, "quantity": 5 }
    /// </remarks>
    /// <param name="productUpdated">Objeto produto com suas informações de atualização</param>
    /// <returns>Não retorna nada</returns>
    /// <response code="204">Sucesso!</response>
    /// <response code="404">Produto não encontrado</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Deleta um produto específico
    /// </summary>
    /// <remarks>
    /// O método DELETE deleta um produto específico no banco de dados.
    /// </remarks>
    /// <param name="id">Identificador (ID) do produto a ser deletado</param>
    /// <returns>Não retorna nada</returns>
    /// <response code="204">Sucesso!</response>
    /// <response code="404">Produto não encontrado</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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