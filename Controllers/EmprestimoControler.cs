using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarioV.Repository;

namespace SeminarioV.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class EmprestimoController : Controller
    {
        /// GET api/values
        [HttpGet]
        public List<Models.Emprestimo> GetEmprestimos()
        {
            var emprestimo = new EmprestimosRepository();
            return emprestimo.Get();
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public string GetEmprestimo(int id)
        {
            return "value";
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.Emprestimo value)
        {
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Emprestimo value)
        {
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
