using System.ComponentModel.DataAnnotations;

namespace BookHub.API.Dtos
{
    public class CreateBookRequestDTO
    {
        [MinLength(5, ErrorMessage = "O Titulo do Livro deve ter mais de 5 caracteres!")]
        [Required(ErrorMessage = "É obrigatório informar o Titulo do livro!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Ano de Publicação do livro!")]
        public DateTime YearPublication { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Numero de Identificação do livro!")]
        [Length(13, 13, ErrorMessage = "O ISBN do Livro deve ter 13 caracteres!")]
        public string ISBN { get; set; }

        [MinLength(15, ErrorMessage = "O resumo do livro deve ter no minímo 15 caracteres")]
        [Required(ErrorMessage = "É obrigatório informar o Resumo do livro!")]
        public string Sumarry { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Escritor do livro!")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a Categoria do livro!")]
        public int CategoryId { get; set; }

    }
}