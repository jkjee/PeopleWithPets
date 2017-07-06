using System.Collections.Generic;
using PeopleWithPets.Library.Models;

namespace PeopleWithPets.Library.Managers
{
    public interface IDataManager
    {
        List<People> GetPeopleWithPets();
        List<People> GetPeopleWithPetType(string type);

        List<Pet> GetPeopleWithPetTypeAndGender(string gender, string type);
    }
}
