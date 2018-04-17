using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;

namespace SeminarioV.Repository
{

    /// <summary>
    /// IUsuariosRepository
    /// </summary>
    public interface IUsuariosRepository
    {
        Usuarios GetByCodigo(int id);
        List<Usuarios> Get();
        void Novo(Usuarios livro);
        void Editar(Usuarios livro);
        void Excluir(int id);
    }

    /// <summary>
    /// UsuariosRepository
    /// </summary>
    public class UsuariosRepository
    {
        public Usuarios GetByCodigo(int id)
        {
            var livro = new Models.Usuarios();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.Usuarios
                                .Where(b => b.Id == id)
                                .FirstOrDefault();
            }
            return livro;
        }

        public List<Usuarios> Get()
        {
            var lista = new List<Usuarios>();
            using (var db = new SeminarioVDbContext())
            {
                lista = db.Usuarios.ToList();
            }
            return lista;
        }

        public void Novo(Usuarios livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Usuarios.Add(livro);
                db.SaveChanges();
            }
        }

        void Editar(Usuarios livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Usuarios.Update(livro);
                db.SaveChanges();
            }
        }

        void Excluir(int id)
        {
            using (var db = new SeminarioVDbContext())
            {
                var livro = db.Usuarios
                                .Where(b => b.Id == id)
                                .FirstOrDefault();

                db.Usuarios.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}