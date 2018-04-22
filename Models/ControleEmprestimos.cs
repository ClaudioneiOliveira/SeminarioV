using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class ControleEmprestimos
    {
        public int Id { get; set; }
        public int IdEmprestimo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataPrevistaDevolucao { get; set; }
        public DateTime? DataRealDevolucao { get; set; }

        public Emprestimos IdEmprestimoNavigation { get; set; }
    }
}
