using System;
using System.Collections.Generic;

namespace SuperSushi.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        [System.ComponentModel.DisplayName("Korting (%)")]
        public int KortingPercentage { get; set; }

        public virtual ICollection<MenuGerecht> Bevat { get; set; }
    }
}
