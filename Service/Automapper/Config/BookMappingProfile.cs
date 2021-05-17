using AutoMapper;
using Mapping.Data.Models;
using Mapping.Dto;

namespace MappingDemo.Service.Automapper.Config
{
	public class BookMappingProfile : Profile
	{
		public BookMappingProfile()
		{
			CreateMap<Author, AuthorDto>().ReverseMap();
			CreateMap<Book, BookDto>();
			CreateMap<Book, BookWithAuthorDto>()
				.ForMember(dest => dest.Year, opt => opt.Ignore())
				.ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(s => s.Author.FirstName + " " + s.Author.LastName));
		}
	}
}
