using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ArkhamAsylum.Lib.Models
{
    public class Floor : Entity
    {
        public int Number { get; set; }

        public Guid BuildingId { get; set; }

        [JsonIgnore]
        public Building Building { get; set; }

        [JsonIgnore]
        public ICollection<Room> Rooms { get; set; }
    }
}
