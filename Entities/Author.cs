using System.ComponentModel.DataAnnotations.Schema;


namespace BookHub.API.Entities
{
    [Table("Authors")]
    public class Author(string Name)
    {
        public int Id { get; set; }
        public string Name { get; set; } = Name;
        public List<Book> Books { get; set; } = [];
    }
}