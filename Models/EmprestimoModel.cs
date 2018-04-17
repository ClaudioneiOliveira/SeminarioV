using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Emprestimo
    {
        public ControleEmprestimos controle { get; set; }
        public Emprestimos emprestimo { get; set; }
        public Livros livro { get; set; }
        public MultaEmprestimos multa { get; set; }
        public Usuarios usuario { get; set; }
    }
}