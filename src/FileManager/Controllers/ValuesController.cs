using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "saeed", "aaa" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public object Post([FromBody]string value)
        {
            return new { Name = "saeed" };
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
