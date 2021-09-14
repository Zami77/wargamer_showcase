using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wargamer_showcase.Data
{
    public class ConvertedPaint
    {
        [JsonProperty(PropertyName = "converted_paint")]
        public String ConvertedPaintName { get; set; }
        [JsonProperty(PropertyName = "by")]
        public String CompanyBy { get; set; }
    }
}
