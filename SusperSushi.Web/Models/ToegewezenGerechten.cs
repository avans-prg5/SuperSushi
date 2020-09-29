using SuperSushi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SusperSushi.Web.Models
{
    public class MenuGerechtenViewModel
    { 
        public Menu Menu { get; set; }
        public List<int> GerechtenBijMenu { get; set; }
    }

    public class ToegewezenGerechten
    {
        public int GerechtId { get; set; }
        public string Omschrijving { get; set; }
        public bool Toegewezen { get; set; }
    }
}
