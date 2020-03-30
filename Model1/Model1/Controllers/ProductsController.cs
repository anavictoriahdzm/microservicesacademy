using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model1.Models;

namespace Model1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Produces("application/json")]
    //[Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId = 0, ProductName = "Laptop", ProducPrice= "200"},
            new Product(){ProductId = 1, ProductName = "SmartPhone", ProducPrice= "100"},
        };

        /*public IEnumerable<Product> Get()
        {
            return _products;
        }*/

        /*public IActionResult Get()
        {
            return Ok(_products);
            //return StatusCode(StatusCodes.Status201Created);
        }*/

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_products);
        }

        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to our store...");
        }

        /*[HttpPost]
        public void Post([FromBody]Product product)
        {
            _products.Add(product);
        }*/

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}