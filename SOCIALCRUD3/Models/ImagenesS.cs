using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class ImagenesS
    {
        public int IdImagen { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
