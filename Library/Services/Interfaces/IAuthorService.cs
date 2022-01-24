using Library.Entities;

namespace Library.Services.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAuthors();
    Task<Author> GetAuthor(int id);
    Task CreateAuthor(Author author);
    Task<bool> UpdateAuthor(Author author);
}
