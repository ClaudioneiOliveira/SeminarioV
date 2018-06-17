using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;

namespace SeminarioV.Repository
{

    /// <summary>
    /// IControleEmprestimosRepository
    /// </summary>
    public interface IControleEmprestimosRepository
    {
        ControleEmprestimos GetByCodigo(int id);
        List<ControleEmprestimos> Get();
        void Novo(ControleEmprestimos livro);
        void Editar(ControleEmprestimos livro);
        void Excluir(int id);
    }

    /// <summary>
    /// ControleEmprestimosRepository
    /// </summary>
    public class ControleEmprestimosRepository
    {
        public ControleEmprestimos GetByCodigo(int id)
        {
            var livro = new Models.ControleEmprestimos();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.ControleEmprestimos
                                .Where(b => b.Id == id)
                                .FirstOrDefault();
            }
            return livro;
        }

        public List<ControleEmprestimos> Get()
        {
            var lista = new List<ControleEmprestimos>();
            using (var db = new SeminarioVDbContext())
            {
                lista = db.ControleEmprestimos.ToList();
            }
            return lista;
        }

        public void Novo(ControleEmprestimos livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.ControleEmprestimos.Add(livro);
                db.SaveChanges();
            }
        }

        public void Editar(ControleEmprestimos livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.ControleEmprestimos.Update(livro);
                db.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var db = new SeminarioVDbContext())
            {
                var livro = db.ControleEmprestimos
                                .Where(b => b.Id == id)
                                .FirstOrDefault();

                db.ControleEmprestimos.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}