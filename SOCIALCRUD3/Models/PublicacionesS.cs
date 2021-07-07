using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class PublicacionesS
    {
        public int IdPublicacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdTypepost { get; set; }
        public string Text { get; set; }
        public int IdImagen { get; set; }
        public int IdPostshared { get; set; }
    }
}
