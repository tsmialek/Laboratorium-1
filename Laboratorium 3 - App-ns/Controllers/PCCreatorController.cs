using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App_ns.Controllers
{
    public class PCCreatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PC pc)
        {
            if (ModelState.IsValid)
            {
                //PcMemoryService : ToDo
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
