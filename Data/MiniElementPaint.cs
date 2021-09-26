using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class MiniElementPaint
    {
        [JsonProperty(PropertyName = "paint_name")]
        public String PaintName { get; set; }
    }
}
