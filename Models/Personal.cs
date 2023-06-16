using System;
using System.Collections.Generic;

namespace LPBD_Backend.Models
{
    public partial class Personal
    {
        public Personal()
        {
            DetalleTareas = new HashSet<DetalleTarea>();
        }

        public int IdPer { get; set; }
        public string? CedPer { get; set; }
        public string? NomPer { get; set; }
        public string? UserPer { get; set; }
        public string? PassPer { get; set; }
        public int? IdRolPer { get; set; }
        public byte? DispPer { get; set; }

        public virtual Role? IdRolPerNavigation { get; set; }
        public virtual ICollection<DetalleTarea> DetalleTareas { get; set; }
    }
}
