using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class ReaccionesS
    {
        public int IdReaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdTypereact { get; set; }
    }
}
