using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSushi.Data
{
    public class GerechtRepositorySql : IGerechtRepository
    {
        readonly SuperSushiContext ctx;

        public GerechtRepositorySql(SuperSushiContext context)
        {
            ctx = context;
        }

        public Gerecht Create(Gerecht gerecht)
        {
            ctx.Gerechten.Add(gerecht);
            ctx.SaveChanges();
            return gerecht;
        }

        public bool Delete(int id)
        {

            var toRemove = ctx.Gerechten.Find(id);
            if (toRemove != null)
            {
                ctx.Gerechten.Remove(toRemove);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Gerecht> GetAll() => ctx.Gerechten.Include(m => m.Onderdeelvan).ToList();

        public Gerecht GetOne(int Id) => ctx.Gerechten.Include(g => g.Onderdeelvan).FirstOrDefault(m => m.Id == Id);

        public Gerecht Update(Gerecht gerecht)
        {
            ctx.Attach(gerecht);
            ctx.Gerechten.Update(gerecht);
            ctx.SaveChanges();
            return gerecht;
        }
    }
}
