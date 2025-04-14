using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Entity;

namespace WebApplication.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductByName(string name);
        Task<List<Product>> GetProductByPrice(decimal downPriceRange, decimal upPriceRange);
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
