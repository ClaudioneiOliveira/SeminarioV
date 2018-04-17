using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SeminarioV.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class EditorasController : Controller
    {
        /// GET api/values
        [HttpGet]
        public IEnumerable<string> GetEditoras()
        {
            return new string[] { "value1", "value2" };
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public string GetEditora(int id)
        {
            return "value";
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.Editoras value)
        {
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Editoras value)
        {
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
