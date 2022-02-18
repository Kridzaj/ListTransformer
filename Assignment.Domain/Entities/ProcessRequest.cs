using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Domain.Entities
{
    public partial class ProcessRequest
    {
        public ProcessRequest()
        {
            Outputs = new HashSet<Output>();
        }

        public int ProcessRequestId { get; set; }
        public Guid Guid { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Processed { get; set; }
        public short ProcessStatusId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Progress { get; set; }

        public virtual ICollection<Output> Outputs { get; set; }
    }
}
