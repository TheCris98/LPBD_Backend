using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class DetalleProyecto
    {
        public int IdDetPro { get; set; }
        public int? IdPro { get; set; }
        public int? IdPer { get; set; }

        public virtual Personal? IdPerNavigation { get; set; }
        public virtual Proyecto? IdProNavigation { get; set; }
    }
}
