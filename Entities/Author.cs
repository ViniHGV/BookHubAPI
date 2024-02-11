using System.ComponentModel.DataAnnotations.Schema;


namespace BookHub.API.Entities
{
    [Table("Authors")]
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}