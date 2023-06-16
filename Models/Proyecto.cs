using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int IdPro { get; set; }
        public string? NomPro { get; set; }
        public string? DescPro { get; set; }
        public DateTime? FecIniPro { get; set; }
        public DateTime? FecFinPro { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
