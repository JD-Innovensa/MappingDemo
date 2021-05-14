using AutoMapper;
using Mapping.Data.Models;
using Mapping.Dto;

namespace MappingDemo.Config
{
	public class BookMappingProfile : Profile
	{
		public BookMappingProfile()
		{
			CreateMap<Author, AuthorDto>().ReverseMap();
			CreateMap<Book, BookDto>();
		}
	}
}
