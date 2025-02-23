using loginProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace loginProject.Controllers
{
    public class InputsController : Controller
    {
        private readonly UserDbContext _context;

        public InputsController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Input input)
        {
            _context.Inputs.Add(input);
            _context.SaveChanges();
            TempData["Success"] = "Successfully Submit";
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
