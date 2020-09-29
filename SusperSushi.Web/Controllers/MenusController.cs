using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperSushi.Data;

namespace SusperSushi.Web.Controllers
{
    public class MenusController : Controller
    {
        IMenuRepository repo = new MenuRepositorySql();

        public IActionResult Index()
        {
            var model = repo.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new Menu());
        }

        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            var model = repo.Create(menu);
            return View("Details",model);
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = new Models.MenuGerechtenViewModel();
                model.Menu = repo.GetOne(id.Value);
                PopulateAssignedGerechten(model.Menu);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Models.MenuGerechtenViewModel model)
        {
            if (id != model.Menu.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var result = repo.Update(model.Menu, model.GerechtenBijMenu);
                return RedirectToAction("Index");
            }
            return View(model);
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

        private void PopulateAssignedGerechten(Menu menu)
        {
            var allGerechten = new GerechtRepositorySql().GetAll();
            var menuGerechtIds = menu.Bevat.Select(m => m.GerechtId);
            var viewModel = new List<Models.ToegewezenGerechten>();
            foreach (var gerecht in allGerechten)
            {
                viewModel.Add(new Models.ToegewezenGerechten
                {
                    GerechtId = gerecht.Id,
                    Omschrijving = gerecht.Omschrijving,
                    Toegewezen = menuGerechtIds.Contains(gerecht.Id)
                });
            }
            ViewData["Gerechten"] = viewModel;
        }
    }
}
