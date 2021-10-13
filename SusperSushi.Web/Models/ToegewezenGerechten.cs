using SuperSushi.Data;
using System.Collections.Generic;

namespace SusperSushi.Web.Models
{
    public class MenuGerechtenViewModel
    { 
        public Menu Menu { get; set; }
        public List<int> GerechtenBijMenu { get; set; }
        public List<ToegewezenGerecht> ToegewezenGerechten { get; set; }
    }

    public class ToegewezenGerecht
    {
        public int GerechtId { get; set; }
        public string Omschrijving { get; set; }
        public bool Toegewezen { get; set; }
    }
}
