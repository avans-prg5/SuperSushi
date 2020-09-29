using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSushi.Data
{
    public class MenuGerecht
    {
        public int MenuId { get; set; }
        public int GerechtId { get; set; }
        public Gerecht Gerecht { get; set; }
        public Menu Menu { get; set; }
    }
}
