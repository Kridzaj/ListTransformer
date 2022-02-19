using Assignment.Application.DTO;
using System;
using System.Threading.Tasks;

namespace Assignment.Web.Data
{
    public interface IListProcessorApi
    {
        Task<Guid> ProcessList(string name, string lastName);

        Task<ProcessRequestDto> GetStatus(Guid guid);
    }
}
