using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _securityManager;
        private readonly SignInManager<ApplicationUser> _loginManager;

        public AccountController(UserManager<ApplicationUser> secMgr, SignInManager<ApplicationUser> loginManager)
        {
            _securityManager = secMgr;
            _loginManager = loginManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
