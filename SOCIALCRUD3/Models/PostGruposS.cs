using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class PostGruposS
    {
        public int IdPublicacion { get; set; }
        public int IdGrupo { get; set; }
        public int IdUser { get; set; }
        public string Texto { get; set; }
        public int IdImagen { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
