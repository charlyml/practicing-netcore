namespace Library.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public ICollection<Book> Books { get; set; }
}
