using Newtonsoft.Json;
using System.Collections.Generic;
using PeopleWithPets.Library.Models;
using System.Net;
using System;
using System.Linq;

namespace PeopleWithPets.Library.Managers
{
    public class DataManager : IDataManager
    {
        private const string DataUrl = "http://agl-developer-test.azurewebsites.net/people.json";
        public List<People> GetPeopleWithPets()
        {
            List<People> people = new List<People>();
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(DataUrl);
                    people = JsonConvert.DeserializeObject<List<People>>(json_data);
                }
                catch (Exception) { }
            }
            return people;
        }

        public List<People> GetPeopleWithPetType(string type)
        {
            var peopleWithPets = GetPeopleWithPets();
            var peopleWithPetTypes = peopleWithPets.Where(p => p.Pets != null && p.Pets.Any(t => t.Type.Equals(type, StringComparison.OrdinalIgnoreCase)))
                                                    .Select(l => new People { Gender = l.Gender, Pets = l.Pets.Where(x => x.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList()}).ToList();
            return peopleWithPetTypes;
        }

        public List<Pet> GetPeopleWithPetTypeAndGender(string gender, string type)
        {
            var peopleWithPetTypes = GetPeopleWithPetType(type);
            var peopleWithPetTypeAndGender = peopleWithPetTypes.Where(p => p.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase))
                                                    .SelectMany(l => l.Pets).OrderBy(o => o.Name).ToList();
            return peopleWithPetTypeAndGender;
        }

    }
}
