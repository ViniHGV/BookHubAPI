using System.ComponentModel.DataAnnotations.Schema;

namespace BookHub.API.Entities
{
    [Table("Categories")]
    public class Category(string Name, string Sumarry)
    {
        public int Id { get; set; }
        public string Name { get; set; } = Name;
        public string Sumarry { get; set; } = Sumarry;
        public List<Book> Books { get; set; } = [];
    }
}