using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module2.Data;
using Module2.Models;
using Module2.Services;

namespace Module2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private ProductsDbContext productsDbContext;
        private IProduct productRepository;

        /*public ProductsController(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }*/

        public ProductsController(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //return productsDbContext.Products;
            return productRepository.GetProducts();
        }
        /*public IEnumerable<Product> Get(string searchProduct)
        {
            var products = productsDbContext.Products.Where(p => p.ProductName.StartsWith(searchProduct));
            return products;
        }*/

        /*public IEnumerable<Product> Get//(int pageNumber, int pageSize)
            (int? pageNumber, int? pageSize)
        {
            var products = from p in productsDbContext.Products.OrderBy(a => a.Id) select p;

            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;

            
            //var items = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();

            return items;
        }*/


        /*public IEnumerable<Product> Get(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = productsDbContext.Products.OrderByDescending(p => p.Price);
                    break;
                case "asc":
                    products = productsDbContext.Products.OrderBy(p => p.Price);
                    break;
                default:
                    products = productsDbContext.Products;
                    break;
            }
            return products;
        }*/

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            //var product = productsDbContext.Products.SingleOrDefault(m => m.Id == id);
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound("No Record Found...");
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //productsDbContext.Products.Add(product);
            //productsDbContext.SaveChanges(true);
            productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id!= product.Id)
            {
                return BadRequest();
            }

            try
            {
                //productsDbContext.Products.Update(product);
                //productsDbContext.SaveChanges(true);
                productRepository.UpdateProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Record Found against this Id...");

            }

            return Ok("Product Updated...");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var product = productsDbContext.Products.SingleOrDefault(m => m.Id == id);
            /*if (product == null)
            {
                return NotFound("No Record Found...");
            }*/

            //productsDbContext.Products.Remove(product);
            //productsDbContext.SaveChanges(true);
            productRepository.DeleteProduct(id);
            return Ok("Product Deleted...");
        }
    }
}
