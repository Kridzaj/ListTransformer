using Assignment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);

    }
}
