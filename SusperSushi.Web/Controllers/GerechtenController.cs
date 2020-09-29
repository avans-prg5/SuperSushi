using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperSushi.Data;

namespace SusperSushi.Web.Controllers
{
    public class GerechtenController : Controller
    {
        IGerechtRepository repo = new GerechtRepositorySql();

        public IActionResult Index()
        {
            var model = repo.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new Gerecht());
        }

        [HttpPost]
        public IActionResult Create(Gerecht gerecht)
        {
            var model = repo.Create(gerecht);
            return View("Details", model);
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var gerecht = repo.GetOne(id.Value);
                return View(gerecht);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Gerecht gerecht)
        {
            if (id != gerecht.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var model = repo.Update(gerecht);
                return RedirectToAction("Index");
            }
            return View(gerecht);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var gerecht = repo.GetOne(id.Value);
            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
