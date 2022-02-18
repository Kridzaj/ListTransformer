using Assignment.Application.DTO;
using Assignment.Domain.Entities;
using AutoMapper;


namespace Assignment.Application.Mappers
{
	public class ProcessRequestProfile : Profile
	{
		public ProcessRequestProfile()
		{
			CreateMap<ProcessRequest, ProcessRequestDto>();
			CreateMap<ProcessRequestDto, ProcessRequest>().ReverseMap();
		}
	}
}
