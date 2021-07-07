using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class Comentario
    {
        public int IdComent { get; set; }
        public string Texto { get; set; }
        public int IdImagen { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdPubli { get; set; }
        public int IdUser { get; set; }
    }
}
