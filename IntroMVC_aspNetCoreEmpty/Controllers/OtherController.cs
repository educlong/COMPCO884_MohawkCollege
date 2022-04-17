using IntroMVC_aspNetCoreEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroMVC_aspNetCoreEmpty.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("stuff/{year:min(2018)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            ViewBag.year = year;
            ViewData["MONTH"] = month;
            ViewBag.key = key;
            return View();
        }

        public IActionResult PageOne()
        {
            var person = new Person
            {
                Id = 1,
                FirstName = "Paul",
                LastName = "Long",
                DateOfBirth = DateTime.Now.AddDays(-10000)
            };
            return View(person);
        }
    }
}
