using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;

namespace SeminarioV.Repository
{
    /// <summary>
    /// IEmprestimosRepository
    /// </summary>
    public interface IEmprestimosRepository
    {
        Emprestimos GetByCodigo(int id);
        List<Emprestimos> Get();
        void Novo(Emprestimos livro);
        void Editar(Emprestimos livro);
        void Excluir(int id);
        bool LivroEmprestado(int id);
    }

    /// <summary>
    /// EmprestimosRepository
    /// </summary>
    public class EmprestimosRepository : IEmprestimosRepository
    {
        public Emprestimos GetByCodigo(int id)
        {
            var livro = new Models.Emprestimos();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.Emprestimos
                                .Where(b => b.Id == id)
                                .FirstOrDefault();
            }
            return livro;
        }

        public bool LivroEmprestado(int id)
        {
            var livro = new Models.Emprestimos();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.Emprestimos
                                .Where(b => b.IdLivro == id 
                                && b.DataRealDevolucao != null
                                && b.DataRealDevolucao <= DateTime.Now)
                                .FirstOrDefault();
            }
            return livro != null ? true : false;
        }

        public List<Emprestimos> Get()
        {
            var lista = new List<Emprestimos>();
            using (var db = new SeminarioVDbContext())
            {
                lista = db.Emprestimos.ToList();
            }
            return lista;
        }

        public void Novo(Emprestimos livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Emprestimos.Add(livro);
                db.SaveChanges();
            }
        }

        public void Editar(Emprestimos livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Emprestimos.Update(livro);
                db.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var db = new SeminarioVDbContext())
            {
                var livro = db.Emprestimos
                                .Where(b => b.Id == id)
                                .FirstOrDefault();

                db.Emprestimos.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}