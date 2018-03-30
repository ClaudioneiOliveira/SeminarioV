using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class MultaEmprestimos
    {
        public int Id { get; set; }
        public int IdEmprestimo { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
    }
}
