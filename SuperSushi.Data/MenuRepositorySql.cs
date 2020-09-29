using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSushi.Data
{
    public class MenuRepositorySql : IMenuRepository
    {
        public Menu Create(Menu menu)
        {
            using (var ctx = new SuperSushiContext())
            {
                ctx.Menus.Add(menu);
                ctx.SaveChanges();
                return menu;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new SuperSushiContext())
            {
                var toRemove = ctx.Menus.Find(id);
                if (toRemove != null)
                {
                    ctx.Menus.Remove(toRemove);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<Menu> GetAll()
        {
            using (var ctx = new SuperSushiContext())
            {
                return ctx.Menus.Include(m => m.Bevat).ToList();
            }
        }

        public Menu GetOne(int id)
        {
            using (var ctx = new SuperSushiContext())
            {
                // load attached items by first loading the
                // relation table and then the Gerechten listed in that
                return ctx.Menus.Include(m => m.Bevat).ThenInclude(i => i.Gerecht).FirstOrDefault(m => m.Id == id);
            }
        }

        public Menu Update(Menu menu, List<int> gerechten)
        {
            using (var ctx = new SuperSushiContext())
            {
                // Attach -> menu item must be known to the context so it can 
                // check whether stuff has changed in it.
                ctx.Attach(menu);
                // Load the old set of gerechten for this menu
                ctx.Entry(menu).Collection(p => p.Bevat).Load();
                var gerechtenInMenu = menu.Bevat.Select(i => i.GerechtId);
               
                foreach (var gerecht in ctx.Gerechten)
                {
                    if (gerechten.Contains(gerecht.Id))
                    {
                        if (!gerechtenInMenu.Contains(gerecht.Id))
                        {
                            menu.Bevat.Add(new MenuGerecht { GerechtId = gerecht.Id, MenuId = menu.Id });
                        }
                    }
                    else
                    {
                        if (gerechtenInMenu.Contains(gerecht.Id))
                        {
                            var itemToRemove = menu.Bevat.FirstOrDefault(m => m.GerechtId == gerecht.Id);
                            ctx.Remove(itemToRemove);
                        }
                    }
                }
                ctx.Menus.Update(menu);
                ctx.SaveChanges();
                return menu;
            }
        }

    }
}
