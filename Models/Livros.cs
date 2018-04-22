using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Livros
    {
        public Livros()
        {
            Emprestimos = new HashSet<Emprestimos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Isbn { get; set; }
        public int Editora { get; set; }
        public int Paginas { get; set; }
        public int Ano { get; set; }
        public string CodBarras { get; set; }
        public string Resenha { get; set; }

        public Editoras EditoraNavigation { get; set; }
        public ICollection<Emprestimos> Emprestimos { get; set; }
    }
}
