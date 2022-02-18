using Assignment.Application.DTO;
using Assignment.Domain.Entities;
using Assignment.Domain.Repositories;
using AutoMapper;
using System;

namespace Assignment.Application.Services
{
    public class ListProcessorService : IListProcessor
    {
        readonly IMapper _mapper;
        readonly IProcessRequestRepository _prRepo;

        public ListProcessorService(IMapper mapper, IProcessRequestRepository processRequestRepository)
        {
            _mapper = mapper;
            _prRepo = processRequestRepository;
        }

        public Guid ProcessList(string name, string lastName)
        {
            ProcessRequest pr = new ProcessRequest();
            pr.Name = name;
            pr.LastName = lastName;
            pr.Guid = Guid.NewGuid();
            _prRepo.Add(pr);
            _prRepo.ExecuteRequest(pr.Guid);
            return pr.Guid;
        }

        public ProcessRequestDto GetStatus(Guid guid)
        {
            return _mapper.Map<ProcessRequestDto>(_prRepo.GetByGuid(guid));
        }
    }
}
