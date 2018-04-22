using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarioV.Models;
using SeminarioV.Repository;

namespace SeminarioV.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class EmprestimoController : Controller
    {
        public EmprestimosRepository emprestimo = new EmprestimosRepository();
        /// GET api/values
        [HttpGet]
        public List<Emprestimos> GetEmprestimos()
        {
            return emprestimo.Get();
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public Emprestimos GetEmprestimo(int id)
        {
            return emprestimo.GetByCodigo(id);
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.Emprestimos value)
        {
            emprestimo.Novo(value);
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Emprestimos value)
        {
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
