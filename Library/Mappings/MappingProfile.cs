using AutoMapper;
using Library.Entities;
using Library.Entities.Dtos;

namespace Library.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorReadDto>().ReverseMap();
        CreateMap<Author, AuthorCreateDto>().ReverseMap();
    }
}