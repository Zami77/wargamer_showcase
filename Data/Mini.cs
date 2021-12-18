using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class Mini
    {
        public Mini()
        {
            Id = Guid.NewGuid().ToString();
        }

        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "mini_name")]
        [Required]
        public String MiniName { get; set; }
        [JsonProperty(PropertyName = "game")]
        [Required]
        public String Game { get; set; }
        [JsonProperty(PropertyName = "faction")]
        [Required]
        public String Faction { get; set; }
        [JsonProperty(PropertyName = "image")]
        public String Image { get; set; }
        [JsonProperty(PropertyName = "elements")]
        public List<MiniElement> Elements { get; set; } = new();
        [JsonProperty(PropertyName = "is_public")]
        public bool IsPublic { get; set; } = false;
        [JsonProperty(PropertyName = "likes")]
        public List<string> Likes { get; set; } = new();
        [JsonProperty(PropertyName = "category")]
        public String Category { get; set; } = "minis";
        [JsonProperty(PropertyName = "_ts")]
        public string TimeStamp { get; set; }
    }
}