namespace Library.Entities;

public class Loan
{
    public int Id { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public int BookId { get; set; }
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public Book Book { get; set; }
    public Customer Customer { get; set; }
    public User User { get; set; }
}