using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroMVC_aspNetCoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return new ContentResult { Content = "from HomeController / Index" };
            return View();
        }
    }
}
