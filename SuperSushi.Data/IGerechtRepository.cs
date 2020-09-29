using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSushi.Data
{
    public interface IGerechtRepository
    {
        List<Gerecht> GetAll();
        Gerecht GetOne(int Id);
        bool Delete(int Id);
        Gerecht Update(Gerecht gerecht);
        Gerecht Create(Gerecht gerecht);
    }
}
