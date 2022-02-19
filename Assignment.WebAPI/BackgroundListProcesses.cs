using Assignment.Application.DTO;
using Assignment.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.WebAPI
{
    public class BackgroundListProcesses
    {
        private Dictionary<Guid,ProcessRequestDto> _processes = new Dictionary<Guid, ProcessRequestDto>();

        public void AddProcess(Guid guid, string name, string lastName)
        {
            _processes[guid] = new ProcessRequestDto()
            {
                Guid = guid,
                Name = name,
                LastName = lastName,
                Progress = 0,
                ProcessStatusId = 1
            };        
        }

        public ProcessRequestDto GetStatus(Guid guid)
        {
            if (_processes.ContainsKey(guid))
            {
                return _processes[guid];
            }
            return null;
        }

        public void ReportProgress(Guid guid, short statusId, int progress,ICollection<OutputDto> outputs)
        {
            if (_processes.ContainsKey(guid))
            {
                _processes[guid].ProcessStatusId = statusId;
                _processes[guid].Progress = progress;
                _processes[guid].Outputs = outputs;
            }
        }

        public async Task RegisterTask(Guid guid, string name, string lastName)
        {
            AddProcess(guid, null, null);

            var rnd = new Random();
            int luck = rnd.Next(1, 4);
            if (luck == 3)
            {
                //Bad luck, it should fail
                ReportProgress(guid, (int)StatusesEnum.Failed, 0, null);
                return;
            }

            List<OutputDto> retVal = new List<OutputDto>();
            for (int i = 0; i <= 100; i++)
            {
                int delay = rnd.Next(200, 600);
                await Task.Delay(delay);
                retVal.Add(ListProcessor.ConstructOutput(i, name, lastName));
                if (i % 10 == 0)
                {
                    ReportProgress(guid, (int)StatusesEnum.InProcess, i, null);
                }

            }
            ReportProgress(guid, (int)StatusesEnum.Finished, 100, retVal);
        }

    }
}
