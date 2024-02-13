using System.ComponentModel.DataAnnotations.Schema;


namespace BookHub.API.Entities
{
    [Table("Books")]
    public class Book(string Title, string iSBN, string Sumarry, DateTime yearPublication, string CategoryName, int authorId, int categoryId)
    {
        public int Id { get; set; }
        public string Title { get; set; } = Title;
        public string ISBN { get; set; } = iSBN;
        public string Sumarry { get; set; } = Sumarry;
        public DateTime YearPublication { get; set; } = yearPublication;
        public string CategoryName { get; set; } = CategoryName;
        public int AuthorId { get; set; } = authorId;
        public Author? Author { get; set; }
        public int CategoryId { get; set; } = categoryId;
        public Category? Category { get; set; }
    }
}