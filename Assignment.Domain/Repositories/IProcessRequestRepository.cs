using Assignment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Repositories
{
    public interface IProcessRequestRepository//generic
    {
        ProcessRequest GetById(int id);
        ProcessRequest GetByGuid(Guid guid);
        IEnumerable<ProcessRequest> GetAll();
        int Add(ProcessRequest entity);
        void ExecuteRequest(Guid guid);

    }
}
