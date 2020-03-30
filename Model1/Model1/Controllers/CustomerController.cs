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
    public class CustomerController : ControllerBase
    {
        List<Customer> _customer = new List<Customer>()
        {
            new Customer(){Id = 0, Name = "Andrew", Email = "andrew@gmail.com", Phone = "555"},
            new Customer(){Id = 1, Name = "Tom", Email = "tom@gmail.com", Phone = "556"}
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customer;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customer.Add(customer);
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}