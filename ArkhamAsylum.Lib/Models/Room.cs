using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ArkhamAsylum.Lib.Models
{
    public class Room : Entity
    {
        public int Number { get; set; }

        public Guid FloorId { get; set; }

        public Guid AreaId { get; set; }

        [JsonIgnore]
        public Floor Floor { get; set; }

        [JsonIgnore]
        public Area Area { get; set; }

        [JsonIgnore]
        public ICollection<Bed> Beds { get; set; }

        [JsonIgnore]
        public ICollection<NurseRoomAssignation> NurseRoomAssignations { get; set; }
    }
}
