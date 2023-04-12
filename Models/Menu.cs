using System;
using System.Collections.Generic;

namespace proyectomenu.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseIdMenuPadreNavigation = new HashSet<Menu>();
        }

        public int IdMenu { get; set; }
        public string? Descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Url { get; set; }

        public virtual Menu? IdMenuPadreNavigation { get; set; }
        public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; }
    }
}
