using Microsoft.AspNetCore.Mvc;
using MyValidationSample.Models;

namespace MyValidationSample.Controllers
{
    public class PersonController : Controller
    {
        private readonly ValidationDbContex _dbContext;

        public PersonController(ValidationDbContex dbContex)
        {
            _dbContext = dbContex;
        }
        public IActionResult Index()
        {
            var people=_dbContext.People.ToList();
            return View(people);
        }
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(SavePersonVm model)

        {
            if (ModelState.IsValid)
            {
                _dbContext.People.Add(new Person { FirstName = model.FirstName, LastName = model.LastName });
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","There is Model Error");
            return View(model);
        }
        public bool CheckName(string userName)
        { 
            if (userName.Length>5)
            { return true; }
            
                return false;
        }
    }
}
