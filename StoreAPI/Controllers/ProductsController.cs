using Microsoft.AspNetCore.Http;
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
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _shopContext.Products.ToList();
            return Ok(products);
        }

        // Could also set the route in the HttpGet Attribute
        // [HttpGet("{id}")]
        [HttpGet]
        [Route("/products/{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _shopContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
