using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeminarioV.Models;
using SeminarioV.Repository;

namespace SeminarioV.Service
{
    /// <summary>
    /// IEmprestimoService
    /// </summary>
    public interface IEmprestimoService
    {
        void Novo(Emprestimo emprestimo);
        void Devolucao(Emprestimo emprestimo);
        bool LivroDisponivel(int id);
    }

    /// <summary>
    /// EmprestimoService
    /// </summary>
    public class EmprestimoService
    {
        public void Novo(Emprestimo operacao)
        {
            var emprestimo = new EmprestimosRepository();
            emprestimo.Novo(operacao);
        }

        public void Devolucao(Emprestimo emprestimo)
        {

        }
        public bool LivroDisponivel(int id)
        {

        }
    }
}