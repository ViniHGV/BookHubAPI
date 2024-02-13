using System.ComponentModel.DataAnnotations;

namespace BookHub.API.Dtos
{
    public class UpdateBookRequestDTO
    {
        [MinLength(5, ErrorMessage = "O Titulo do Livro deve ter mais de 5 caracteres!")]
        public string Title { get; set; }
        public DateTime YearPublication { get; set; }

        [Length(13, 13, ErrorMessage = "O ISBN do Livro deve ter 13 caracteres!")]
        public string ISBN { get; set; }

        [MinLength(15, ErrorMessage = "O resumo do livro deve ter no minímo 15 caracteres")]
        public string Sumarry { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}