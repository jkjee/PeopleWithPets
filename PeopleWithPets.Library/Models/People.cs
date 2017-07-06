using Newtonsoft.Json;
using System.Collections.Generic;

namespace PeopleWithPets.Library.Models
{
    public class People
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
