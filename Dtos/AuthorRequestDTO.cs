using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookHub.API.Dtos
{
    public class AuthorRequestDTO
    {
        [NotNull]
        [MinLength(5, ErrorMessage = "O Nome deve ter mais de 5 caracteres!")]
        [Required(ErrorMessage = "É obrigatório inserir o Nome do Autor!")]
        [Display(Name = "Nome conpleto do Autor!")]
        public string Name { get; set; }
    }
}