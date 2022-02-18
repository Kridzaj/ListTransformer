using Assignment.Application.DTO;
using System;

namespace Assignment.Application.Services
{
    public interface IListProcessor
    {
        Guid ProcessList(string name, string lastName);

        ProcessRequestDto GetStatus(Guid guid);
    }
}
