using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Interface;
using WebApplication.Services.Models.Product;

namespace WebApplications.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductController(IProductService _productService) : ControllerBase
    {
        [HttpGet("Test")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllData()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("GetAllProductByName")]
        public async Task<IActionResult> GetAllData(string name)
        {
            return Ok(await _productService.GetAllProductByName(name));
        }

        [HttpGet("GetAllProductByPrice")]
        public async Task<IActionResult> GetAllData(decimal downPrice, decimal upPrice)
        {
            return Ok(await _productService.GetAllProductByPriceRange(downPrice, upPrice));
        }

        [HttpPost("InsertProduct")]
        public async Task<IActionResult> InsertData(ProductInputtedModel model)
        {
            return Ok(await _productService.InsertProduct(model));
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateData(ProductInputtedModel model, string id)
        {
            return Ok(await _productService.UpdateProduct(model, id));
        }
    }
}
