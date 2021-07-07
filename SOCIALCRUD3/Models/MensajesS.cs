using System;
using System.Collections.Generic;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class MensajesS
    {
        public int IdMsj { get; set; }
        public int IdEmisor { get; set; }
        public int IdReceptor { get; set; }
        public string Texto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
