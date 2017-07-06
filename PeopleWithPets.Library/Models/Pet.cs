using Newtonsoft.Json;

namespace PeopleWithPets.Library.Models
{
    public class Pet
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
