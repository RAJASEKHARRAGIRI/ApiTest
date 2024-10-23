using ApiTest.Contracts;
using ApiTest.Controllers;
using ApiTest.Entity;
using ApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.UnitTests
{
    public class ProductControllerTests
    {
        IProducts _service;
        ProductsController _controller;

        public ProductControllerTests()
        {
            var context = new AppDBContext(new DbContextOptionsBuilder<AppDBContext>()
                        .UseInMemoryDatabase(databaseName: "ApiTestDB")
                        .Options);

            _service = new Products(context);
            _controller = new ProductsController(_service);
        }

        [Fact]
        public void GetAll_Products_Success()
        {
            var result = _controller.GetProducts();
            var resultType = result;
            Assert.NotNull(resultType);
        }

        [Fact]
        public void Get_Product_Success()
        {
            var inputId = 1;
            var result = _controller.GetProduct(inputId);
            Assert.NotNull(result);
            Assert.Equal(1, inputId);
        }
    }
}