using Assignment.Application.DTO;
using Assignment.Domain.Entities;
using Assignment.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;

namespace Assignment.Application.Services
{
    public class ListProcessorService : IListProcessor
    {
        readonly IMapper _mapper;
        readonly IProcessRequestRepository _prRepo;
        private readonly ILogger<ListProcessorService> _logger;

        public ListProcessorService(IMapper mapper, IProcessRequestRepository processRequestRepository, ILogger<ListProcessorService> logger)
        {
            _mapper = mapper;
            _prRepo = processRequestRepository;
            _logger = logger;
        }
        public Guid ProcessList(string name, string lastName)
        {
            _logger.LogInformation($"Received list for {name} {lastName}");
            ProcessRequest pr = new ProcessRequest();
            pr.Name = name;
            pr.LastName = lastName;
            pr.Guid = Guid.NewGuid();
            try
            {
                _prRepo.Add(pr);
                _prRepo.ExecuteRequest(pr.Guid);
                return pr.Guid;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error processing list");
                throw;
            }
        }
        public ProcessRequestDto GetStatus(Guid guid)
        {
            _logger.LogInformation($"Fetching status for {guid}");
            try
            {
                return _mapper.Map<ProcessRequestDto>(_prRepo.GetByGuid(guid));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error getting status");
                throw;
            }
        }
    }
}
