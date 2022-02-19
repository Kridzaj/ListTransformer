using Assignment.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.ConsoleApp;

namespace Assignment.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListProcessorController : ControllerBase
    {
        private readonly ILogger<ListProcessorController> _logger;
        private BackgroundListProcesses _bgListProcesses;
        public ListProcessorController(ILogger<ListProcessorController> logger, BackgroundListProcesses bgListProcesses)
        {
            _logger = logger;
            _bgListProcesses = bgListProcesses;
        }
        [HttpGet("{guid}", Name = "getStatus")]
        public ProcessRequestDto GetStatus(Guid guid)
        {
            return _bgListProcesses.GetStatus(guid);
        }

        [HttpGet("{name}/{lastname}", Name = "getList")]
        public Guid GetList(string name, string lastname)
        {
            var guid = Guid.NewGuid();
            Task newTask = Task.Run(() => _bgListProcesses.RegisterTask(guid, name, lastname));
            return guid;
        }

        
    }
}
