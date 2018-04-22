using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Emprestimos
    {
        public Emprestimos()
        {
            ControleEmprestimos = new HashSet<ControleEmprestimos>();
            MultaEmprestimos = new HashSet<MultaEmprestimos>();
        }

        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataPrevistaDevolucao { get; set; }
        public DateTime? DataRealDevolucao { get; set; }

        public Livros IdLivroNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<ControleEmprestimos> ControleEmprestimos { get; set; }
        public ICollection<MultaEmprestimos> MultaEmprestimos { get; set; }
    }
}
