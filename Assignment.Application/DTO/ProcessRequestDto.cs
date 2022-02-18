using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Application.DTO
{
    public partial class ProcessRequestDto
    {
        public ProcessRequestDto()
        {
            Outputs = new HashSet<OutputDto>();
        }

        public Guid Guid { get; set; }
        public short ProcessStatusId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Progress { get; set; }

        public virtual ICollection<OutputDto> Outputs { get; set; }
    }
}
