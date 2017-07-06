using System.Collections.Generic;
using System.Web.Mvc;
using PeopleWithPets.Library.Managers;
using PeopleWithPets.Library.Models;

namespace PeopleWithPets.Controllers
{
    public class PeopleWithPetsController : Controller
    {
        // GET: PeopleWithPets
        public ActionResult Index()
        {
            var dataManager = new DataManager();
            var catsByMale = dataManager.GetPeopleWithPetTypeAndGender("male", "cat");
            var catsByFemale = dataManager.GetPeopleWithPetTypeAndGender("female", "cat");
            Dictionary<string, List<Pet>> pets = new Dictionary<string, List<Pet>>();

            pets.Add("Male", catsByMale);
            pets.Add("Female", catsByFemale);

            return View(pets);
        }
    }
}