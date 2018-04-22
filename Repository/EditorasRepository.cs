using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;

namespace SeminarioV.Repository
{

    /// <summary>
    /// IEditorasRepository
    /// </summary>
    public interface IEditorasRepository
    {
        Editoras GetByCodigo(int id);
        List<Editoras> Get();
        void Novo(Editoras livro);
        void Editar(Editoras livro);
        void Excluir(int id);
    }

    /// <summary>
    /// EditorasRepository
    /// </summary>
    public class EditorasRepository
    {
        public Editoras GetByCodigo(int id)
        {
            var livro = new Models.Editoras();
            using (var db = new SeminarioVDbContext())
            {
                livro = db.Editoras
                                .Where(b => b.Id == id)
                                .FirstOrDefault();
            }
            return livro;
        }

        public List<Editoras> Get()
        {
            var lista = new List<Editoras>();
            using (var db = new SeminarioVDbContext())
            {
                lista = db.Editoras.ToList();
            }
            return lista;
        }

        public void Novo(Editoras editora)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Editoras.Add(editora);
                db.SaveChanges();
            }
        }

        void Editar(Editoras livro)
        {
            using (var db = new SeminarioVDbContext())
            {
                db.Editoras.Update(livro);
                db.SaveChanges();
            }
        }

        void Excluir(int id)
        {
            using (var db = new SeminarioVDbContext())
            {
                var livro = db.Editoras
                                .Where(b => b.Id == id)
                                .FirstOrDefault();

                db.Editoras.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}