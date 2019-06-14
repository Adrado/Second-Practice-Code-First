using Newtonsoft.Json;
using System;

namespace ArkhamAsylum.Lib.Models
{
    public class Diagnosis : Entity
    {
        public string Code { get; set; }
        public Guid DoctorId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
