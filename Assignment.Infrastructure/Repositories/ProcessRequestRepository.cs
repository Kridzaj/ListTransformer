using Assignment.Domain;
using Assignment.Domain.Entities;
using Assignment.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Repositories
{
    public class ProcessRequestRepository : RepositoryBase<ProcessRequest>, IProcessRequestRepository
    {
        private readonly DbSet<ProcessRequest> _entitySet;

        public ProcessRequestRepository(ABNContext dbContext) 
            : base(dbContext)
        {
            _entitySet = _dbContext.Set<ProcessRequest>();
        }

        public ProcessRequest GetByGuid(Guid guid)
        => _entitySet.FirstOrDefault(e => e.Guid == guid);

        public void ExecuteRequest(Guid guid)
        {
           
                var param = new SqlParameter("@Guid", guid.ToString());
                _dbContext.Database.ExecuteSqlRaw("exec dbo.ExecuteRequest @Guid", param);
                ProcessRequest pr = GetByGuid(guid);
                _dbContext.Entry(pr).State = EntityState.Detached;
                pr = GetByGuid(guid);
        }
    }
}
