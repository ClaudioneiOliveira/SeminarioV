using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;

namespace SeminarioV.Repository
{

    /// <summary>
    /// ILivrosRepository
    /// </summary>
    public interface ILivrosRepository
    {
        Livros GetByCodigo(int id);
        List<Livros> Get();
    }

    /// <summary>
    /// LivrosRepository
    /// </summary>
    public class LivrosRepository
    {
        public Livros GetByCodigo(int id)
        {
            return new Livros();
        }
        public List<Livros> Get()
        {
            var lista = new List<Livros>();
            return lista;
        }
    }
}