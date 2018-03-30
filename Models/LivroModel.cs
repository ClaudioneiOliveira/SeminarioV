namespace SeminarioV.Models
{
    /// <summary>
    /// Informações dos livros
    /// </summary>
    public class LivroModel
    {
        /// numero do livro no banco
        public int id {get; set;}
        /// Nome do Livro
        public string nome {get; set;}
        ///Código do ISBN
        public string isbn {get; set;}
        /// Id da editora
        public int editora  {get; set;}
        /// Nro de paginas
        public int paginas {get; set;}
        /// Ano de lancamento do livro
        public int ano  {get; set;}
        /// Abstract do livro
        public string resenha  {get; set;}
    }
}