using System.ComponentModel.DataAnnotations.Schema;


namespace BookHub.API.Entities
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime YearPublication { get; set; }
        public string ISBN { get; set; }
        public string Sumarry { get; set; }
    }
}