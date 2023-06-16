using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class DetalleTarea
    {
        public int IdDetTar { get; set; }
        public int? IdTar { get; set; }
        public int? IdPer { get; set; }

        public virtual Personal? IdPerNavigation { get; set; }
        public virtual Tarea? IdTarNavigation { get; set; }
    }
}
