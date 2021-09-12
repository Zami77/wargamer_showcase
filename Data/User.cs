using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wargamer_showcase.Data
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string username, string email)
        {
            Id = Guid.NewGuid().ToString();
            Username = username;
            Email = email;
        }

        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "username")]
        public String Username { get; set; }
        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

    }
}
