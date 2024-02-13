using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookHub.API.Dtos
{
    public class CreateAuthorRequestDTO
    {
        [NotNull]
        [MinLength(5, ErrorMessage = "O Nome do Autor deve ter mais de 5 caracteres!")]
        [Required(ErrorMessage = "É obrigatório inserir o Nome do Autor!")]
        [Display(Name = "Nome completo do Autor!")]
        public string Name { get; set; }
    }
}