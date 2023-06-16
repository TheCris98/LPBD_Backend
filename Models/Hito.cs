using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class Hito
    {
        public Hito()
        {
            DetalleHitos = new HashSet<DetalleHito>();
        }

        public int IdHit { get; set; }
        public DateTime? FecLimHit { get; set; }

        public virtual ICollection<DetalleHito> DetalleHitos { get; set; }
    }
}
