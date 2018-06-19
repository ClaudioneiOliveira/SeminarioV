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
    public class EditorasController : Controller
    {
        public EditorasRepository editora = new EditorasRepository();
        /// GET api/values
        [HttpGet]
        public List<Editoras> GetEditoras()
        {
             return editora.Get();
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public Editoras GetEditora(int id)
        {
            return editora.GetByCodigo(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Editoras value)
        {
            editora.Novo(value);
            return Created("Criado",value);
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Editoras value)
        {
            editora.Editar(value);
            return Ok(value);
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            editora.Excluir(id);
        }
    }
}
