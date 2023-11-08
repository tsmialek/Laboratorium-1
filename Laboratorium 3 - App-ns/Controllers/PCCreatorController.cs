using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App_ns.Controllers
{
    public class PCCreatorController : Controller
    {
        private static Dictionary<int, PC> _PCdict = new Dictionary<int, PC>();

        public IActionResult Index()
        {
            return View(_PCdict);
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
                pc.Id = _PCdict.Count + 1;
                _PCdict.Add(pc.Id, pc);
                return RedirectToAction("Index");
            }
            else
            {
                // Jeśli model nie jest poprawny, przypisz klasy do odpowiednich pól
                foreach (var key in ModelState.Keys)
                {
                    // Ustaw klasę na 'is-invalid' lub 'is-valid' w zależności od stanu walidacji pola
                    var errorCount = ModelState[key].Errors.Count;
                    ViewData[key + "Class"] = errorCount > 0 ? "is-invalid" : "is-valid";
                }

                // Zwróć ten sam widok z aktualnym modelem do poprawy
                return View(pc);
            }
        }
    }
}
