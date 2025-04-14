using Microsoft.EntityFrameworkCore;
using WebApplication.Repositories.Entity;
using WebApplication.Repositories.Interface;

namespace WebApplication.Repositories.Repository
{
    public class ProductRepository(AppDbContext _db) : IProductRepository
    {
        public Task<List<Product>> GetAllProduct()
            => _db.Products.ToListAsync();

        public Task<Product> GetProductById(int id)
            => _db.Products.FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<Product>> GetProductByName(string name)
            => _db.Products.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();

        public Task<List<Product>> GetProductByPrice(decimal downPriceRange, decimal upPriceRange)
            => _db.Products.Where(x => x.Price >= downPriceRange && x.Price <= upPriceRange).ToListAsync();

        public async Task InsertProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
