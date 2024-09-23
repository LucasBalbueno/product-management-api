# ProductManagementApi

A `ProductManagementApi` é uma API RESTful para gerenciar produtos. Ela permite criar, ler, atualizar e deletar produtos em um banco de dados. A API foi desenvolvida utilizando ASP.NET Core e segue as melhores práticas de desenvolvimento de APIs.

<br>

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção de aplicações web e APIs.
- **Dapper**: ORM para acesso ao banco de dados.
- **SQLite**: Banco de dados relacional leve em memória.
- **Swagger/OpenAPI**: Ferramenta para documentação e teste da API.
- **Postman**: Ferramenta para testar as requisições da API.

<br>

## 📋 Funcionalidades

- **Criar Produto**: Adiciona um novo produto ao banco de dados.
- **Listar Produtos**: Retorna uma lista de todos os produtos.
- **Lista Produto específico**: Retorna um produto específico.
- **Atualizar Produto**: Atualiza as informações de um produto existente.
- **Deletar Produto**: Remove um produto do banco de dados.

<br>

## 💻 Instruções para Rodar o Projeto

### Pré-requisitos:

- [.NET 6 SDK ou superior](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

### Instruções para executar:

1. Clone o repositório no seu terminal;
   ```bash
   git clone https://github.com/LucasBalbueno/product-management-api
   cd ProductManagementApi
   ```
2. Digite no terminal/console dentro da pasta `ProductManagementApi`:
   ```bash
    dotnet run
   ```
3. Irá abrir a documentação do Swagger no seu navegador;

### Instruções do Postman:
Para testar a API no Postman, você pode importar a coleção.

1. Copie o script da coleção condfigurado:
```bash
{
	"info": {
		"_postman_id": "06735eb3-7ded-42c8-8936-fcfce704a39d",
		"name": "ProductManagementApi",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
		"_exporter_id": "38537766"
	},
	"item": [
		{
			"name": "Get All Products",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "http://localhost:5012/api/Product",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "5012",
					"path": [
						"api",
						"Product"
					]
				}
			},
			"response": []
		},
		{
			"name": "Get Product by Id",
			"request": {
				"method": "GET",
				"header": [
					{
						"key": "Id",
						"value": "1",
						"type": "text",
						"disabled": true
					}
				],
				"url": {
					"raw": "http://localhost:5012/api/Product/:id",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "5012",
					"path": [
						"api",
						"Product",
						":id"
					],
					"variable": [
						{
							"key": "id",
							"value": ""
						}
					]
				}
			},
			"response": []
		},
		{
			"name": "Create Product",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n  \"name\": \"New Name\",\r\n  \"price\": 100,\r\n  \"quantity\": 1\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:5012/api/Product",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "5012",
					"path": [
						"api",
						"Product"
					]
				}
			},
			"response": []
		},
		{
			"name": "Update Product",
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n  \"id\": 1,\r\n  \"name\": \"Name Updated\",\r\n  \"price\": 100,\r\n  \"quantity\": 5\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:5012/api/Product/",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "5012",
					"path": [
						"api",
						"Product",
						""
					]
				}
			},
			"response": []
		},
		{
			"name": "Delete Product",
			"request": {
				"method": "DELETE",
				"header": [],
				"url": {
					"raw": "http://localhost:5012/api/Product/:id",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "5012",
					"path": [
						"api",
						"Product",
						":id"
					],
					"variable": [
						{
							"key": "id",
							"value": ""
						}
					]
				}
			},
			"response": []
		}
	]
}
```

2. Abra o Postman;
3. Clique em "Import" no canto superior esquerdo;
4. Cole o JSON acima.
5. A coleção será configurada e agora você pode fazer os testes. 

**OBS**: Lembre-se de alterar os parâmetros da URL e do body request para executar as funcionalidades corretamente;