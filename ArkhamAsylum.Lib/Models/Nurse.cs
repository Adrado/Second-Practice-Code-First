using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ArkhamAsylum.Lib.Models
{
    public class Nurse : Entity
    {
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSutname { get; set; }
        public Guid AreaId { get; set; }
        [JsonIgnore]
        public Area Area { get; set; }
        [JsonIgnore]
        public ICollection<NurseRoomAssignation> NurseRoomAssignations { get; set; }
    }
}
