using ArkhamAsylum.Lib.Services.CountryConnectors;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArkhamAsylum.Lib.Models
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSutname { get; set; }
        [JsonIgnore]
        public ICollection<Record> Records { get; set; }
    }
}
