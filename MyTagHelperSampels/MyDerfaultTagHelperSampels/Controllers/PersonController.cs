﻿using Microsoft.AspNetCore.Mvc;
using MyDerfaultTagHelperSampels.Models;

namespace MyDerfaultTagHelperSampels.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View(new Person());
        }
        [HttpPost]
        public IActionResult Save(Person person)
        {
            return RedirectToAction("Save");
        }
    }
}
