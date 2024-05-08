using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildController : ControllerBase
    {
        // GET: api/<BuildController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BuildController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BuildController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BuildController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuildController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
