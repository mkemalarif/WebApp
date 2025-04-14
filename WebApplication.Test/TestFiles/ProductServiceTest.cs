using Microsoft.Extensions.Logging;
using Moq;
using WebApplication.Repositories.Entity;
using WebApplication.Repositories.Interface;
using WebApplication.Services.Models.Product;
using WebApplication.Services.Service;

namespace WebApplication.Test.TestFiles
{
    [TestClass]
    public class ProductServiceTest
    {
        ProductService _productService;
        Mock<IProductRepository> _productRepoMock = new();
        Mock<ILogger<ProductService>> _loggerMock = new();

        [TestInitialize]
        public void Initialize()
        {
            #region data mocked
            var lstProductDummy = new List<Product>()
            {
                new()
                {
                        Id = 1,
                        Name = "Test",
                        Description = "Ok",
                        Price = 32000,
                        CreatedAt = DateTime.Now.AddDays(-2)
                },
                new()
                {
                    Id = 2,
                    Name = "Test2",
                    Description = "Ok",
                    Price = 30000,
                    CreatedAt = DateTime.Now.AddDays(-3)
                }
            };
            #endregion

            _productRepoMock.Setup(x => x.GetAllProduct()).ReturnsAsync(lstProductDummy);
            _productRepoMock.Setup(x => x.GetProductByPrice(It.IsAny<decimal>(), It.IsAny<decimal>())).ReturnsAsync(lstProductDummy);
            _productRepoMock.Setup(x => x.GetProductByName(It.IsAny<string>())).ReturnsAsync(lstProductDummy);
            _productRepoMock.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(lstProductDummy.FirstOrDefault());


            _productService = new(
                _productRepo: _productRepoMock.Object,
                _logger: _loggerMock.Object
                );
        }

        [TestMethod]
        public async Task GetAllProduct_IsNotNull()
        {
            var result = await _productService.GetAllProduct();
            Assert.IsTrue(result.Count() > 0);

            _productRepoMock.Verify(x => x.GetAllProduct(), Times.Once());
        }

        [TestMethod]
        public async Task GetAllProductName_IsNotNull()
        {
            var result = await _productService.GetAllProductByName("Test");
            Assert.IsTrue(result.Count() > 0);

            _productRepoMock.Verify(x => x.GetProductByName(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public async Task GetAllProductPrice_IsNotNull()
        {
            var result = await _productService.GetAllProductByPriceRange(30000, 32000);
            Assert.IsTrue(result.Count() > 0);

            _productRepoMock.Verify(x => x.GetProductByPrice(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once());
        }

        [TestMethod]
        public async Task InsertProduct_IsNotNull()
        {
            ProductInputtedModel mockedData = new()
            {
                Name = "Test",
                Description = "Ok",
                Price = 30000
            };

            var result = await _productService.InsertProduct(mockedData);
            Assert.IsNotNull(result);

            _productRepoMock.Verify(x => x.InsertProduct(It.IsAny<Product>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateProduct_IsNotNull()
        {
            ProductInputtedModel mockedData = new()
            {
                Name = "TestNew",
                Description = "Ok",
                Price = 50000
            };

            var result = await _productService.UpdateProduct(mockedData, "1");
            _productRepoMock.Verify(x => x.UpdateProduct(It.IsAny<Product>()), Times.Once());
            _productRepoMock.Verify(x => x.GetProductById(It.IsAny<int>()), Times.Once());
        }
    }
}
