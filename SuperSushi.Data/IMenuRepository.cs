using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSushi.Data
{
    public interface IMenuRepository
    {
        List<Menu> GetAll();
        Menu GetOne(int id);
        bool Delete(int Id);
        Menu Update(Menu menu, List<int> gerechten);
        Menu Create(Menu menu);
    }
}
