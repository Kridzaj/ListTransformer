using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Domain.Entities
{
    public partial class Output
    {
        public int OutputId { get; set; }
        public int Ordinal { get; set; }
        public string Value { get; set; }
        public int ProcessRequestId { get; set; }

        public virtual ProcessRequest ProcessRequest { get; set; }
    }
}
