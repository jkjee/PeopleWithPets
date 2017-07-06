using NUnit.Framework;
using PeopleWithPets.Library.Managers;

namespace PeopleWithPets.Tests
{
    public class DataManagerTest
    {
        private static readonly IDataManager DataManager = new DataManager();

        [Test]
        public void GetPeopleWithPets()
        {
            var peopleWithPets = DataManager.GetPeopleWithPets();
            CollectionAssert.IsNotEmpty(peopleWithPets);
        }

        [TestCase("Cat")]
        [TestCase("Dog")]
        [TestCase("Fish")]
        public void GetPeopleWithPetTypes(string type)
        {
            var peopleWithPets = DataManager.GetPeopleWithPetType(type);
            CollectionAssert.IsNotEmpty(peopleWithPets);
        }

        [TestCase("Male","Cat", 4)]
        [TestCase("Female","Dog",0)]
        [TestCase("Female", "Fish", 1)]
        [TestCase("male", "dog", 2)]
        public void GetPeopleWithPetTypeAndGender(string gender, string type, int count)
        {
            var peopleWithPets = DataManager.GetPeopleWithPetTypeAndGender(gender, type);
            Assert.AreEqual(peopleWithPets.Count, count);
        }
    }
}
