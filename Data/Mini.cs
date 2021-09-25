using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class Mini
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "mini_name")]
        public String MiniName { get; set; }
        [JsonProperty(PropertyName = "game")]
        public String Game { get; set; }
        [JsonProperty(PropertyName = "faction")]
        public String Faction { get; set; }
        [JsonProperty(PropertyName = "image")]
        public String Image { get; set; }
        [JsonProperty(PropertyName = "elements")]
        public List<MiniElement> Elements { get; set; } = new();
    }
}