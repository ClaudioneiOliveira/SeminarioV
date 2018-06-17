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
    public class UsuariosController : Controller
    {
        public UsuariosRepository usuarios = new UsuariosRepository();
        /// GET api/values
        [HttpGet]
        public List<Usuarios> GetUsuarios()
        {
            return usuarios.Get();
        }

        /// GET api/values/5
        [HttpGet("{id}")]
        public Usuarios GetUsuario(int id)
        {
            return usuarios.GetByCodigo(id);
        }

        /// POST api/values
        [HttpPost]
        public void Post([FromBody] Models.Usuarios value)
        {
            usuarios.Novo(value);
        }

        /// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Usuarios value)
        {
            usuarios.Editar(value);
        }

        /// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usuarios.Excluir(id);
        }
    }
}
