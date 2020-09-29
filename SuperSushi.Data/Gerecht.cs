using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperSushi.Data
{
    public class Gerecht
    {
        public int Id { get; set; }
        public Soort Soort { get; set; }
        [StringLength(150)]
        public string Omschrijving {get;set;}
        [Range(0,100)]
        public decimal Prijs { get; set; }

        public virtual ICollection<MenuGerecht> Onderdeelvan { get; set; }
    }

    public enum Soort { 
        Vis,
        Vlees,
        Vega,
        Insect
    }
}
