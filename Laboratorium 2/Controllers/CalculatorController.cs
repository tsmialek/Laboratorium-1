using Microsoft.AspNetCore.Mvc;
using Laboratorium_2.Models;

namespace Laboratorium_2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Calculator calc)
        {
            if (!calc.IsValid())
                return BadRequest();

            return View(calc);
        }
    }
}
