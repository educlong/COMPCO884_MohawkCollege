using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureSite_aspNetCoreWebApp_ModelViewControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSite_aspNetCoreWebApp_ModelViewControl.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
    }
}
