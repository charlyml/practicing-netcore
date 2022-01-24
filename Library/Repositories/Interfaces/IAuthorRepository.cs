using Library.Entities;

namespace Library.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> GetAuthorAsync(int id);
    Task CreateAuthorAsync(Author author);
    Task<bool> UpdateAuthor(Author author);
}
