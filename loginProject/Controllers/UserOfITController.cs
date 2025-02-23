using loginProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace loginProject.Controllers
{
    public class UserOfITController : Controller
    {
        private readonly UserDbContext _context;

        public UserOfITController(UserDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string UserName, string password)
        {
            var user = _context.LoginData.FirstOrDefault(u => u.UserName == UserName && u.Password == password);

            if (user != null && user.UserName == "Amol" && user.Password == "123")
            {
                
                TempData["Success"] = "Login successful!";
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Error = "Invalid Username or password.";
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            {
                var itEmployees = _context.Inputs
                                          .Where(u => u.JobDescription == "IT")
                                          .Select(u => new
                                          {
                                              u.Name,
                                              u.JobDescription,
                                              u.Salary
                                          })
                                          .ToList();

                ViewBag.ITEmployees = itEmployees;
                return View();
            }
        }
    }
}
