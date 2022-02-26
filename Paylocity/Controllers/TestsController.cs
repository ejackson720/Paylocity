using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paylocity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        // GET: api/<TestsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "test1", "test2" };
        }

        // GET api/<TestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
