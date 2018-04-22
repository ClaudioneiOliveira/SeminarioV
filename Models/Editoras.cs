using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Editoras
    {
        public Editoras()
        {
            Livros = new HashSet<Livros>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Livros> Livros { get; set; }
    }
}
