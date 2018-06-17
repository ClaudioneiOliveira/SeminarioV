using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Livros
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Isbn { get; set; }
        public int Editora { get; set; }
        public int Paginas { get; set; }
        public int Ano { get; set; }
        public string CodBarras { get; set; }
        public string Resenha { get; set; }
    }
}
