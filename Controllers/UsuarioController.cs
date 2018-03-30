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
    public class UsuariosController : Controller
    {
        /// GET api/values
        [HttpGet]
        public IEnumerable<string> GetUsuarios()
        {
            return new string[] { "value1", "value2" };
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public string GetUsuario(int id)
        {
            return "value";
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.Usuarios value)
        {
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Usuarios value)
        {
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
