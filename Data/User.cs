using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class User
    {
        public User(string username)
        {
            Id = Guid.NewGuid().ToString();
            Username = username;
        }
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "username")]
        public String Username { get; set; }

    }
}
