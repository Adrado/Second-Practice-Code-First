using Newtonsoft.Json;
using System;

namespace ArkhamAsylum.Lib.Models
{
    public class Bed : Entity
    {
        public string Code { get; set; }

        public Guid RoomId { get; set; }

        [JsonIgnore]
        public Room Room { get; set; }

        public int RoomNumber
        {
            get
            {
                return Room.Number;
            }
        }
    }
}
