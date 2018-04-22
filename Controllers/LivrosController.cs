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
    public class LivrosController : Controller
    {
        public LivrosRepository livros = new LivrosRepository();
        /// GET api/values
        [HttpGet]
        public List<Livros> GetLivros()
        {
            return livros.Get();
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public Livros GetLivro(int id)
        {
            return livros.GetByCodigo(id);
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.Livros value)
        {
            livros.Novo(value);
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Livros value)
        {
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
