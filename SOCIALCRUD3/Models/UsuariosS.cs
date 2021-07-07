using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class UsuariosS
    {
        public int IdUser { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
    }
}
