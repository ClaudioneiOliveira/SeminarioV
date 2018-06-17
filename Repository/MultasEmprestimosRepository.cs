using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;

namespace SeminarioV.Repository
{

    /// <summary>
    /// IMultasEmprestimosRepository
    /// </summary>
    public interface IMultaEmprestimosRepository
    {
        MultaEmprestimos GetByCodigo(int id);
        List<MultaEmprestimos> Get();
        void Novo(MultaEmprestimos livro);
        void Editar(MultaEmprestimos livro);
        void Excluir(int id);
    }

    /// <summary>
    /// MultasEmprestimosRepository
    /// </summary>
    public class MultasEmprestimosRepository
    {
        public MultaEmprestimos GetByCodigo(int id)
        {
            var livro = new Models.MultaEmprestimos();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.MultaEmprestimos
                                .Where(b => b.Id == id)
                                .FirstOrDefault();
            }
            return livro;
        }

        public List<MultaEmprestimos> Get()
        {
            var lista = new List<MultaEmprestimos>();
            using (var db = new SeminarioVDbContext())
            {
                lista = db.MultaEmprestimos.ToList();
            }
            return lista;
        }

        public void Novo(MultaEmprestimos livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.MultaEmprestimos.Add(livro);
                db.SaveChanges();
            }
        }

        public void Editar(MultaEmprestimos livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.MultaEmprestimos.Update(livro);
                db.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var db = new SeminarioVDbContext())
            {
                var livro = db.MultaEmprestimos
                                .Where(b => b.Id == id)
                                .FirstOrDefault();

                db.MultaEmprestimos.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}