using EmployeeManagement.Context;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.CustomSessions;
using EmpManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, EmployeeContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                if (User.Identity.Name != "admin@nitor.com")
                {
                    var findEmp = (await _signInManager.UserManager.Users.ToListAsync()).Find(c => c.Email == User.Identity.Name);
                    var fetchUser = _userManager.Users.Where(u => u.Email == findEmp.Email).FirstOrDefault();
                    var checkRoleIsAssigned = await _userManager.GetRolesAsync(fetchUser);
                    if (checkRoleIsAssigned.Count > 0)
                    {
                        var loggedInEmp = (await _context.employees.ToListAsync()).Where(c => c.EmailId == findEmp.Email).ToList()[0];
                        var leaves = (await _context.leaves.ToListAsync()).Where(c => c.EmployeeId == loggedInEmp.EmployeeId).ToList();
                        var inv = (await _context.investments.ToListAsync()).ToList().FindAll(c => c.EmployeeId == loggedInEmp.EmployeeId).Count();
                        ViewBag.InvestmentCount = inv;
                        ViewBag.CasualCount = leaves.FindAll(c => c.LeaveType == "Casual").Count();
                        ViewBag.MedicalCount = leaves.FindAll(c => c.LeaveType == "Medical").Count();
                        HttpContext.Session.SetSessionObject<EmployeeModel>("loginUser", loggedInEmp);
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Role is not assigned,please contact HR or administrator");
                        HttpContext.Session.Clear();
                        await _signInManager.SignOutAsync();
                        _logger.LogInformation("User logged out.");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
