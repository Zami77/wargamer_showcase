using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class Paint
    {
        public Paint()
        {
            Id = Guid.NewGuid().ToString();
        }
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "paint_name")]
        public String PaintName { get; set; }
        [JsonProperty(PropertyName = "company")]
        public String Company { get; set; }
        [JsonProperty(PropertyName = "hex_color")]
        public String HexColor { get; set; }
        [JsonProperty(PropertyName = "color_conversions")]
        public List<ConvertedPaint> ColorConversions { get; set; }
    }
}
