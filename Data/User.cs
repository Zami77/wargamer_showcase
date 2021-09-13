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
        [JsonProperty(PropertyName = "paints")]
        public List<PaintInventory> Paints { get; set; } = new List<PaintInventory>();
        [JsonProperty(PropertyName = "minis")]
        public List<Mini> Minis { get; set; } = new List<Mini>();
        [JsonProperty(PropertyName = "favorite_minis")]
        public List<Mini> FavoriteMinis { get; set; } = new List<Mini>();
        [JsonProperty(PropertyName = "category")]
        public String Category { get; set; } = "users";

    }
}
