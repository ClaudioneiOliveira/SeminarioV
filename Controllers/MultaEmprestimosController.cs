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
    public class MultaEmprestimosController : Controller
    {
        public MultasEmprestimosRepository multaEmprestimos = new MultasEmprestimosRepository();
        /// GET api/values
        [HttpGet]
        public List<MultaEmprestimos> GetMultaEmprestimo()
        {
            return multaEmprestimos.Get();
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public MultaEmprestimos GetUsuario(int id)
        {
            return multaEmprestimos.GetByCodigo(id);
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.MultaEmprestimos value)
        {
            multaEmprestimos.Novo(value);
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.MultaEmprestimos value)
        {
            multaEmprestimos.Editar(value);
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            multaEmprestimos.Excluir(id);
        }
    }
}
