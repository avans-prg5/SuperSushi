using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperSushi.Data
{
    public class MenuGerecht
    {
        [Key]
        public int MenuId { get; set; }
        [Key]
        public int GerechtId { get; set; }
        public Gerecht Gerecht { get; set; }
        public Menu Menu { get; set; }
    }
}
