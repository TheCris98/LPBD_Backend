using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class Tarea
    {
        public Tarea()
        {
            DetalleHitos = new HashSet<DetalleHito>();
            DetalleTareas = new HashSet<DetalleTarea>();
        }

        public int IdTar { get; set; }
        public int? IdProTar { get; set; }
        public byte[]? NomTar { get; set; }
        public string? DescTar { get; set; }
        public DateTime? FecIniTar { get; set; }
        public DateTime? FecFinTar { get; set; }
        public byte? EstTar { get; set; }
        public decimal? AvanceTar { get; set; }

        public virtual Proyecto? IdProTarNavigation { get; set; }
        public virtual ICollection<DetalleHito> DetalleHitos { get; set; }
        public virtual ICollection<DetalleTarea> DetalleTareas { get; set; }
    }
}
