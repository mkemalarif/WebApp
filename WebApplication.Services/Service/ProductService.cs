using Microsoft.Extensions.Logging;
using WebApplication.Repositories.Entity;
using WebApplication.Repositories.Interface;
using WebApplication.Services.Interface;
using WebApplication.Services.Models.Product;

namespace WebApplication.Services.Service
{
    public class ProductService(IProductRepository _productRepo, ILogger<ProductService> _logger) : IProductService
    {
        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
                return await _productRepo.GetAllProduct();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }

        public async Task<List<Product>> GetAllProductByName(string name)
        {
            try
            {
                return await _productRepo.GetProductByName(name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }

        public async Task<List<Product>> GetAllProductByPriceRange(decimal downPriceRange, decimal upPriceRange)
        {
            try
            {
                return await _productRepo.GetProductByPrice(downPriceRange, upPriceRange);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }

        public async Task<string> InsertProduct(ProductInputtedModel param)
        {
            try
            {
                Product newProduct = new Product()
                {
                    Name = param.Name,
                    Description = param.Description,
                    Price = param.Price,
                    CreatedAt = DateTime.Now
                };

                await _productRepo.InsertProduct(newProduct);

                return "Insert Success";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }

        public async Task<string> UpdateProduct(ProductInputtedModel param, string id)
        {
            try
            {
                var existedProduct = await _productRepo.GetProductById(Int32.Parse(id));

                if (existedProduct == null)
                {
                    return "Product not found";
                }

                existedProduct.Price = param.Price;
                existedProduct.Name = param.Name;
                existedProduct.Description = param.Description;

                await _productRepo.UpdateProduct(existedProduct);

                return "Update Success";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }
    }
}
