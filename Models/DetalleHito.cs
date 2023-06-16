using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class DetalleHito
    {
        public int IdDetHit { get; set; }
        public int? IdHit { get; set; }
        public int? IdTar { get; set; }

        public virtual Hito? IdHitNavigation { get; set; }
        public virtual Tarea? IdTarNavigation { get; set; }
    }
}
