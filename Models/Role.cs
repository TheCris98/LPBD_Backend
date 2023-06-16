using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class Role
    {
        public Role()
        {
            Personals = new HashSet<Personal>();
        }

        public int IdRol { get; set; }
        public string? NomRol { get; set; }
        public string? DescRol { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
    }
}
