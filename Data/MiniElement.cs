using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class MiniElement
    {
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "paints_used")]
        public List<MiniElementPaint> PaintsUsed { get; set; } = new();
        [JsonProperty(PropertyName = "parent_mini")]
        public String ParentMini { get; set; }
    }
}