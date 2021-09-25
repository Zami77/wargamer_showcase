using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class MiniElement
    {
        public MiniElement()
        {
            Id = Guid.NewGuid().ToString();
        }

        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "paints_used")]
        public List<String> PaintsUsed { get; set; } = new();
        [JsonProperty(PropertyName = "parent_mini")]
        public Mini ParentMini { get; set; } = new();
    }
}