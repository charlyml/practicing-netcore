namespace Library.Entities;

public class Book
{
    public int Id { get; set; }
    public int Pages { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public int Isbn { get; set; }
    public string Editorial { get; set; }
    public DateOnly PublicationDate { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<Loan> Loans { get; set; }
    public ICollection<Author> Authors { get; set; }

}
