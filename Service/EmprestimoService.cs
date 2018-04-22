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
        void Novo(Emprestimos emprestimo);
        void Devolucao(Emprestimos emprestimo);
        bool LivroDisponivel(int id);
    }

    /// <summary>
    /// EmprestimoService
    /// </summary>
    public class EmprestimoService
    {
        public void Novo(Emprestimos operacao)
        {
            var emprestimo = new EmprestimosRepository();
            //emprestimo.Novo(operacao);
        }

        public void Devolucao(Emprestimos emprestimo)
        {

        }
        public bool LivroDisponivel(int id)
        {
            return true;
        }
    }
}