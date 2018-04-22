using System;
using System.Collections.Generic;

namespace SeminarioV.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Emprestimos = new HashSet<Emprestimos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Emprestimos> Emprestimos { get; set; }
    }
}
