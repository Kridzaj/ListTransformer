using Assignment.Application.Services;
using Assignment.ConsoleApp;
using Assignment.Domain.Repositories;
using Assignment.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using Assignment.Application.Mappers;

namespace Assignment.UnitTests
{
    public class ListProcessorServiceTests
    {
        private IMapper _mapper;
        private IProcessRequestRepository _prRepo;
        private ILogger<ListProcessorService> _logger;
        private ListProcessorService _service;

        [SetUp]
        public void Setup()
        {
            var repository = new Mock<IProcessRequestRepository>();
            repository.Setup(r => r.GetByGuid(
                It.IsAny<Guid>())).Returns((Guid g) => new ProcessRequest()
                {
                    Guid = g,
                    Progress = 50,
                    Name = "TestName",
                    LastName = "TestLast"
                });;
            _prRepo = repository.Object;

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OutputProfile());
                mc.AddProfile(new ProcessRequestProfile());
            });
            _mapper = mapperConfig.CreateMapper();

            var logger = new Mock<ILogger<ListProcessorService>>();
            _logger = logger.Object;
            _service = new ListProcessorService(_mapper, _prRepo, _logger);
        }

        [Test]
        public void TestGetStatus()
        {

            var guid = Guid.NewGuid();
            var retVal = _service.GetStatus(guid);
            Assert.AreEqual(retVal.Guid, guid, "Error getting status");
            Assert.AreEqual(retVal.Name, "TestName", "Error getting Name");
            Assert.AreEqual(retVal.LastName, "TestLast", "Error getting LastName");
            Assert.AreEqual(retVal.Progress, 50, "Error getting Progress");
        }

        [Test]
        public void TestProcessList()
        {
            var retVal = _service.ProcessList("TestName", "LastName");
            Assert.IsNotNull(retVal, "Error processing list");
            Assert.AreNotEqual(retVal, Guid.Empty, "Error! Received empty Guid");
        }

          
    }
}