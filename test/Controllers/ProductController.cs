using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IBusinessProduct businessProduct;

        public ProductController(IBusinessProduct businessProduct)
        {
            this.businessProduct = businessProduct;
        }



        // GET: api/<ProductsController>
        [HttpGet("getall")]
        public async Task<List<Product>> Get()
        {
            return await businessProduct.GetAll();
        }

        // interval
        [HttpGet("{minPrice}/{maxPrice}")]
        public List<Product> GetInterval(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) return new List<Product>();
            return businessProduct.GetInterval(minPrice, maxPrice);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            return Ok(businessProduct.Insert(product));
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
