using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Entity;
using WebApplication.Services.Models.Product;

namespace WebApplication.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<List<Product>> GetAllProductByName(string name);
        Task<List<Product>> GetAllProductByPriceRange(decimal downPriceRange, decimal upPriceRange);
        Task<string> InsertProduct(ProductInputtedModel param);
        Task<string> UpdateProduct(ProductInputtedModel param, string id);
    }
}
