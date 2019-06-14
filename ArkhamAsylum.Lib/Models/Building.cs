using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArkhamAsylum.Lib.Models
{
    public class Building : Entity
    {
        public string Code { get; set; }

        public string Address { get; set; }

        [JsonIgnore]
        public ICollection<Floor> Floors { get; set; }
    }
}
