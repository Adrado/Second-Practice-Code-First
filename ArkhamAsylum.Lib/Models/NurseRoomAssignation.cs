using Newtonsoft.Json;
using System;

namespace ArkhamAsylum.Lib.Models
{
    public class NurseRoomAssignation : Entity
    {
        public string Code { get; set; }
        public Guid NurseId { get; set; }
        [JsonIgnore]
        public Nurse Nurse { get; set; }
        public Guid RoomId { get; set; }
        [JsonIgnore]
        public Room Room { get; set; }
    }
}
