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
        void Novo(Livros livro);
        void Editar(Livros livro);
        void Excluir(int id);
    }

    /// <summary>
    /// LivrosRepository
    /// </summary>
    public class LivrosRepository
    {
        public Livros GetByCodigo(int id)
        {
            var livro = new Models.Livros();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.Livros
                                .Where(b => b.Id == id)
                                .FirstOrDefault();
            }
            return livro;
        }

        public List<Livros> Get()
        {
            var lista = new List<Livros>();
            using (var db = new SeminarioVDbContext())
            {
                lista = db.Livros.ToList();
            }
            return lista;
        }

        public void Novo(Livros livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Livros.Add(livro);
                db.SaveChanges();
            }
        }

        public void Editar(Livros livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Livros.Update(livro);
                db.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var db = new SeminarioVDbContext())
            {
                var livro = db.Livros
                                .Where(b => b.Id == id)
                                .FirstOrDefault();

                db.Livros.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}