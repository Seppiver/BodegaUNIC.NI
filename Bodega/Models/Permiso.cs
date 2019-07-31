using System;
using System.Collections.Generic;

namespace Bodega.Models
{
    public partial class Permiso
    {
        public int IdPermiso { get; set; }
        public byte IdPerfil { get; set; }
        public int IdPantalla { get; set; }
        public byte IdRecinto { get; set; }
        public int IdPermisoName { get; set; }
        public string LoginCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LoginModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string LoginEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public virtual Pantalla IdPantallaNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual PermisoName IdPermisoNameNavigation { get; set; }
        public virtual Usuario LoginCreacionNavigation { get; set; }
    }
}
