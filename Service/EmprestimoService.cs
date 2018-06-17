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
            var livro = new LivrosRepository();
            if (LivroDisponivel(operacao.IdLivro))
            {
                operacao.DataPrevistaDevolucao = DateTime.Now.AddDays(7);
                operacao.DataRealDevolucao = null;
                operacao.DataRetirada = DateTime.Now;
                emprestimo.Novo(operacao);
            }
        }

        public void Devolucao(int id)
        {
            var emprRepo = new EmprestimosRepository();
            var emp = emprRepo.GetByCodigo(id);
            emp.DataRealDevolucao = DateTime.Now;
            emprRepo.Editar(emp);
        }
        public bool LivroDisponivel(int id)
        {
            var livro = new LivrosRepository();
            var livroDisp = livro.GetByCodigo(id);
            if (livroDisp == null)
            {
                return false;
            }
            var emprest = new EmprestimosRepository();
            var disp = emprest.LivroEmprestado(id);
            return disp;
        }
    }
}