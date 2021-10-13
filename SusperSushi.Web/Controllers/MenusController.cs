using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperSushi.Data;

namespace SusperSushi.Web.Controllers
{
    public class MenusController : Controller
    {
        readonly IMenuRepository menuRepo;
        readonly IGerechtRepository gerechtRepo;
        public MenusController(IMenuRepository injectedMenuRepository, IGerechtRepository injectedGerechtRepository)
        {
            menuRepo = injectedMenuRepository;
            gerechtRepo = injectedGerechtRepository;
        }

        public IActionResult Index() => View(menuRepo.GetAll());

        public IActionResult Create() => View(new Menu());

        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            return View("Details", menuRepo.Create(menu));
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                // viewmodel aanmaken
                var model = new Models.MenuGerechtenViewModel();
                // databehoefte van formulier vervullen
                // te wijzigen menu ophalen
                model.Menu = menuRepo.GetOne(id.Value);
                // keuzelijstjes vullen
                PopulateAssignedGerechten(ref model);
                // view (en viewdata) teruggeven.
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
                menuRepo.Update(model.Menu, model.GerechtenBijMenu);
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

            var menu = menuRepo.GetOne(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
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

        private void PopulateAssignedGerechten(ref Models.MenuGerechtenViewModel model)
        {

            // Alle gerechten ophalen : Databehoefte
            var allGerechten = gerechtRepo.GetAll();
            // lijstje vullen met id's van gerechten die al in het menu zitten
            var menuGerechtIds = model.Menu.Bevat.Select(m => m.GerechtId);
            model.ToegewezenGerechten = new List<Models.ToegewezenGerecht>();
            foreach (var gerecht in allGerechten)
            {
                model.ToegewezenGerechten.Add(new Models.ToegewezenGerecht
                {
                    GerechtId = gerecht.Id,
                    Omschrijving = gerecht.Omschrijving,
                    Toegewezen = menuGerechtIds.Contains(gerecht.Id)
                });
            }
  
        }
    }
}
