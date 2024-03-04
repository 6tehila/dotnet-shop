using Microsoft.AspNetCore.Mvc;
using Shop.Core.Entities;
using Shop.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prod=_productService.GetProductById(id);
            if(prod == null)
                return NotFound();  
            return Ok(prod);
            
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            var productToAdd=new Product { Id = product.Id,Name=product.Name,Price=product.Price,Quantity=product.Quantity };
            var newProduct = await _productService.AddProductAsync(product);
            return Ok(newProduct); 
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            return Ok(_productService.UpdateProduct(id, product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);  
            return Ok();
        }
    }
}
