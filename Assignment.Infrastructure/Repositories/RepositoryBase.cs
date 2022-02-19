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
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ABNContext _dbContext;
        private readonly DbSet<ProcessRequest> _entitySet;

        public RepositoryBase(ABNContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<ProcessRequest>();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public T Add(T entity)
        {
            _dbContext.Add(entity);
            SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

    }
}
