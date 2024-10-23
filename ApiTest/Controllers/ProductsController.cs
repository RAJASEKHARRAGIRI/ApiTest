using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Contracts;
using ApiTest.Entity;
using ApiTest.Services;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _products;
        public ProductsController( IProducts products)
        {
            _products = products;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Product>> GetProducts([System.Web.Http.FromUri]string productName = "", [System.Web.Http.FromUri] string category = "")
        {
            return await _products.GetAllProducts(productName, category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _products.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product p)
        {
            if (id != p.Id)
            {
                return BadRequest();
            }

            var product = await _products.UpdateProduct(id, p);
            if(product == null)
            {
                return NoContent();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var res = await _products.CreateProduct(product);
            if (res == null)
            {
                return BadRequest();
            }
            return res;
        }
    }
}
