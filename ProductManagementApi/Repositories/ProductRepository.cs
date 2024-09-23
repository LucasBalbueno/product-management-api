using System.Data;
using System.Data.SQLite;
using Dapper;
using ProductManagementApi.Models;

namespace ProductManagementApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _config;

    private readonly string _connectionString;

    public ProductRepository(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("default");
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        using IDbConnection connection = new SQLiteConnection(_connectionString);
        string sql = "select * from Product";
        var products = await connection.QueryAsync<Product>(sql);
        return products;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        using IDbConnection connection = new SQLiteConnection(_connectionString);
        string sql = "select * from Product where Id=@id";
        var product = await connection.QueryFirstOrDefaultAsync<Product>(sql, new { id });
        return product;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        using IDbConnection connection = new SQLiteConnection(_connectionString);
        string sql = @"insert into Product (Name,Price,Quantity) values (@Name,@Price,@Quantity);
                       SELECT last_insert_rowid()";
        int createdId = await connection.ExecuteScalarAsync<int>(sql, new
        {
            product.Name,
            product.Price,
            product.Quantity
        });
        product.Id = createdId;
        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        using IDbConnection connection = new SQLiteConnection(_connectionString);
        string sql = @"update Product set Name=@Name,Price=@Price,Quantity=@Quantity where Id=@Id";
        await connection.ExecuteAsync(sql, new { product });
    }

    public async Task DeleteProductAsync(int id)
    {
        using IDbConnection connection = new SQLiteConnection(_connectionString);
        string sql = @"delete from Product where Id=@id";
        await connection.ExecuteAsync(sql, new { id });
    }
}