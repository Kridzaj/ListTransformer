using Assignment.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.ConsoleApp;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Assignment.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListProcessorController : ControllerBase
    {
        private readonly ILogger<ListProcessorController> _logger;
        private readonly BackgroundListProcesses _bgListProcesses;
        public ListProcessorController(ILogger<ListProcessorController> logger, BackgroundListProcesses bgListProcesses)
        {
            _logger = logger;
            _bgListProcesses = bgListProcesses;
        }
        [HttpGet("{guid}", Name = "getStatus")]
        public ActionResult<ProcessRequestDto> GetStatus(Guid guid)
        {
            _logger.LogInformation($"Fetching status for {guid}");
            try
            {
                var retVal = _bgListProcesses.GetStatus(guid); 
                if (retVal!=null)
                {
                    return retVal;
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error on GetStatus");
                return NotFound();
            }
        }

        [HttpGet("{name}/{lastname}", Name = "getList")]
        public ActionResult<Guid> GetList(string name, string lastname)
        {
            _logger.LogInformation($"Received list for {name} {lastname}");
            try
            {
                var guid = Guid.NewGuid();
                Task newTask = Task.Run(() => _bgListProcesses.RegisterTask(guid, name, lastname));
                return guid;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on GetList");
                return Problem();
            }           
        }        
    }
}
