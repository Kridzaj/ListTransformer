using Assignment.Application.DTO;
using Assignment.Domain.Entities;
using AutoMapper;


namespace Assignment.Application.Mappers
{
	public class OutputProfile : Profile
	{
		public OutputProfile()
		{
			CreateMap<Output, OutputDto>();
			CreateMap<OutputDto, Output>().ReverseMap();
		}
	}
}
