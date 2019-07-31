using System;
using System.Collections.Generic;

namespace Bodega.Models
{
    public partial class UsuarioPerfil
    {
        public byte IdPerfil { get; set; }
        public string Login { get; set; }
        public string LoginCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LoginModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string LoginEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario LoginNavigation { get; set; }
    }
}
