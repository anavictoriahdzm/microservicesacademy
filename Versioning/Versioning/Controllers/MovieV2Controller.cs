using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Versioning.Models;

namespace Versioning.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/movies")]
    [ApiController]
    public class MovieV2Controller : ControllerBase
    {
        public class MoviesV1Controller : ControllerBase
        {
            static List<MoviesV2> _movies = new List<MoviesV2>()
            {
                new MoviesV2(){Id=0, MovieDescription="It's an action film by Keany Reeves", MovieName="John Wick", Type="Action"},
                new MoviesV2(){Id=1, MovieDescription= "Action film by Keau Reeves", MovieName = "John Wick 2", Type = "Action"}
            };
            // GET: api/MovieV2
            [HttpGet]
            public IEnumerable<MoviesV2> Get()
            {
                return _movies;
            }

            // GET: api/MovieV2/5
            [HttpGet("{id}", Name = "Get")]
            public string Get(int id)
            {
                return "value";
            }

            // POST: api/MovieV2
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT: api/MovieV2/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        }
    }
}
