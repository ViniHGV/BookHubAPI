using System.ComponentModel.DataAnnotations;

namespace BookHub.API.Dtos
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "É obrigatório informar o nome da Categoria!")]
        [MinLength(3, ErrorMessage = "O nome da categoria tem que ter no minímo 3 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É obrigatório informar um resumo sobre a Categoria!")]
        [MinLength(15, ErrorMessage = "O resumo sobre a categoria tem que ter no minímo 15 caracteres!")]

        public string Sumarry { get; set; }
    }
}