using Newtonsoft.Json;
using System;

namespace ArkhamAsylum.Lib.Models
{
    public class Record : Entity
    {
        public string Code { get; set; }

        public Guid PatientId { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }

        public Guid BedId { get; set; }

        [JsonIgnore]
        public Bed Bed { get; set; }

        public Guid DiagnosisId { get; set; }

        [JsonIgnore]
        public Diagnosis Diagnosis { get; set; }

    }
}
