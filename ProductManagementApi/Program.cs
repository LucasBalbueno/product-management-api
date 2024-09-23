using Microsoft.OpenApi.Models;
using ProductManagementApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "ProductManagementApi",
        Version = "v1",
        Contact = new OpenApiContact {
            Name = "Lucas Balbueno Vicêncio",
            Email = "balbuenolucas04@gmail.com",
            Url = new Uri("https://github.com/LucasBalbueno")
        }
    });

    var xmlFile = "ProductManagementApi.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();