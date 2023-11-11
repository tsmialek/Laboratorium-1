using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App_ns.Controllers
{
    public class PCCreatorController : Controller
    {
        private readonly IPCCreatorService _pcCreatorService;

        public PCCreatorController(IPCCreatorService pcCreatorService)
        {
            _pcCreatorService = pcCreatorService;
        }

        public IActionResult Index()
        {
            return View(_pcCreatorService.GetAll());
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
                _pcCreatorService.Add(pc);
                return RedirectToAction("Index");
            }
            else
            {
                SetValidationClasses();

                // Zwróć ten sam widok z aktualnym modelem do poprawy
                return View(pc);
            }
        }

        public IActionResult Details(int id)
        {
            return View(_pcCreatorService.FindById(id));
        }

        public IActionResult Delete(int id)
        {
            _pcCreatorService.Delete(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_pcCreatorService.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(PC pc)
        {
            if (ModelState.IsValid)
            {
                _pcCreatorService.Update(pc);
                return RedirectToAction("Index");
            }
            else
            {
                 SetValidationClasses();

                // Zwróć ten sam widok z aktualnym modelem do poprawy
                return View(pc);
            }
        }
        
        private void SetValidationClasses()
        {
            foreach (var key in ModelState.Keys)
            {
                // Ustaw klasę na 'is-invalid' lub 'is-valid' w zależności od stanu walidacji pola
                var errorCount = ModelState[key].Errors.Count;
                ViewData[key + "Class"] = errorCount > 0 ? "is-invalid" : "is-valid";
            }
        }

    }
}
