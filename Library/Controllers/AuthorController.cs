using AutoMapper;
using Library.Entities;
using Library.Entities.Dtos;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        IEnumerable<Author> authors = await _authorService.GetAuthors();
        var authorsDto = _mapper.Map<IEnumerable<AuthorReadDto>>(authors);

        return Ok(authorsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _authorService.GetAuthor(id);

        if (author == null)
        {
            return NotFound();
        }
        
        var authorDto = _mapper.Map<AuthorReadDto>(author);

        return Ok(authorDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(AuthorCreateDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        await _authorService.CreateAuthor(author);
        authorDto = _mapper.Map<AuthorCreateDto>(author);

        return Ok(authorDto);

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatedAuthor(int id, AuthorReadDto authorDto)
    {
        try
        {
            if (id != authorDto.Id)
                return BadRequest("Employee Id mismatch");
        
            var authorToUpdate = await _authorService.GetAuthor(id);

            if (authorToUpdate == null)
                return NotFound("Employee not found");

            await _authorService.UpdateAuthor(authorToUpdate);
            
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating author record");
        }
    }
}
