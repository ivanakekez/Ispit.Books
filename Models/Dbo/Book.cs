namespace Ispit.Books.Models.Dbo
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }

        public Author? Author { get; set; }
        public int? AuthorId { get; set; }

        public Publisher? Publisher { get; set; }
        public int? PublisherId { get; set; }
    }

}
