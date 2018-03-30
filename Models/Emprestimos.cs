using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Emprestimos
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataPrevistaDevolucao { get; set; }
        public DateTime? DataRealDevolucao { get; set; }
    }
}
