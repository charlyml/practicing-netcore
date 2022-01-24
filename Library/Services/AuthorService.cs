using Library.Entities;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public Task<IEnumerable<Author>> GetAuthors() => _authorRepository.GetAuthorsAsync();
    
    public async Task<Author> GetAuthor(int id) => await _authorRepository.GetAuthorAsync(id);

    public async Task CreateAuthor(Author author)
    {
        await _authorRepository.CreateAuthorAsync(author);
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        var existingAuthor = await _authorRepository.GetAuthorAsync(author.Id);
        if (existingAuthor == null)
            return false;

        existingAuthor.Name = author.Name;
        existingAuthor.Lastname = author.Lastname;

        var wasCreated = await _authorRepository.UpdateAuthor(existingAuthor);
        
        return wasCreated;
    }
}
