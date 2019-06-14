using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArkhamAsylum.Lib.Models
{
    public class Area : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Nurse> Nurses { get; set; }

        [JsonIgnore]
        public ICollection<Doctor> Doctors { get; set; }
    }
}
