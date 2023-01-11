using EmployeeManagement.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class LeaveController : Controller
    {
        EmployeeContext _employeeContext;
        public LeaveController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
