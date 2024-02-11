using System.ComponentModel.DataAnnotations.Schema;

namespace BookHub.API.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sumarry { get; set; }
        public List<Book> Books { get; set; }
    }
}