using Microsoft.AspNetCore.Mvc;
using mvcCore.Models.Domain;

namespace mvcCore.Controllers
{
    public class PersonController : Controller
    {

        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx;

        }
        public IActionResult Index()
        {

            // Parsing static item from the controller to the layout (Person)
            //View Bag / Data Only sends data from controller to view 
            ViewBag.greeting = "Hello World !";
            ViewData["greeting2"] = "I am using ViewData for this ";
            // Temp Data can send data from one controller method to another controller method
            // Action method to Actin method 
            TempData["greeting3"] = "It is TempData Message";
            return View();
        }
        // get the methods ( are they usually get methods by default or not ?
        public IActionResult AddPerson()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                //business logic , operation on the models 
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added Sucessfully ";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Couldn't be added ";
                return View();
            }





        }
        public IActionResult DisplayPeople()
        {
            //ctx is the repository layer 
            // model is a not a shown variable such as people 
            var people = _ctx.Person.ToList();

            return View(people);
        }

        //editing people information 
        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);


            return View(person);
        }


        //deleting people 
        public IActionResult DeletePerson(int id)
        {


            try
            {
                var person = _ctx.Person.Find(id);
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {


            }

            return RedirectToAction("DisplayPeople");








        }
        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var fetchedPerson = _ctx.Person.Find(person.Id);
                if (fetchedPerson != null)
                {
                    fetchedPerson.Name = person.Name;
                    fetchedPerson.Email = person.Email;
                    _ctx.Person.Update(fetchedPerson);
                    _ctx.SaveChanges();
                    TempData["msg"] = "Updated Sucessfully ";
                    return RedirectToAction("DisplayPeople");
                }


            }
            catch (Exception ex)
            {
                TempData["msg"] = "Couldn't be updated ";
                return View();
            }



            return View();

        }
    }


}
