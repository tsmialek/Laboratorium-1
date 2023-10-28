using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App_ns.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        // zwracanie formularza dodawania kontaktu
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                // zapamiętanie kontaktu - modelu
                _contactService.Add(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            if(ModelState.IsValid)
            {
                _contactService.Update(contact);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
