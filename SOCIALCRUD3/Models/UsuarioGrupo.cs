using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class UsuarioGrupo
    {
        public int IdUser { get; set; }
        public int IdGrupo { get; set; }
        public string TipoUsuario { get; set; }
    }
}
