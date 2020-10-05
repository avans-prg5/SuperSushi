using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SuperSushi.Data
{
    public class Menu
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength =5)]
        public string Naam { get; set; }
        [DisplayName("Korting (%)")]
        public int KortingPercentage { get; set; }

        public virtual ICollection<MenuGerecht> Bevat { get; set; }
    }
}
