using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Assignment.Application.DTO
{
    public partial class ProcessRequestDto
    {
        public ProcessRequestDto()
        {
            Outputs = new HashSet<OutputDto>();
        }

        [JsonPropertyName("Guid")]
        [Required]
        public Guid Guid { get; set; }
        [JsonPropertyName("ProcessStatusId")]
        public short ProcessStatusId { get; set; }
        [JsonPropertyName("ProcessStatus")]
        public string ProcessStatus 
        {
            get
            {
                switch (ProcessStatusId)
                {
                    case (int)StatusesEnum.Registered:
                        return "Registered";
                    case (int)StatusesEnum.InProcess:
                        return "InProcess";
                    case (int)StatusesEnum.Finished:
                        return "Finished";
                    case (int)StatusesEnum.Failed:
                        return "Failed";
                    default:
                        return "";
                }
            }
        }
        [JsonPropertyName("Name")]
        [MinLength(2, ErrorMessage = "Name must contain atleast 2 characters.")]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "Last Name must contain atleast 2 characters.")]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Progress")]
        public int? Progress { get; set; }

        [JsonPropertyName("Outputs")]
        public virtual ICollection<OutputDto> Outputs { get; set; }
    }
}
