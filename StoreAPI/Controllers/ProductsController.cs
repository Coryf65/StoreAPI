using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StoreAPI_MVC.Models;

namespace StoreAPI_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _shopContext;

        public ProductsController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated(); // make sure to Seed DB
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = _shopContext.Products.ToArray();
            return Ok(products);
        }

        /// <summary>
        /// Async Get all Products to an Array
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var products = await _shopContext.Products.ToArrayAsync();
            return Ok(products);
        }


        // Could also set the route in the HttpGet Attribute
        // [HttpGet("{id}")]
        [HttpGet]
        [Route("/products/{id}")]
        public async Task<ActionResult> GetProductAsync(int id)
        {
            var product = await _shopContext.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Add some custom error handling
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _shopContext.Products.Add(product);

            await _shopContext.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id },
                product);
        }

    }
}
