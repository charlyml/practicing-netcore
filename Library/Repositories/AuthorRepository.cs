using Library.Entities;
using Library.Persistence;
using Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task CreateAuthorAsync(Author author)
    {
        _context.Authors.Add(author);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        _context.Authors.Update(author);

        var rows = await _context.SaveChangesAsync();

        return rows > 0;
    }
}
