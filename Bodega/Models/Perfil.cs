using System;
using System.Collections.Generic;

namespace Bodega.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Permiso = new HashSet<Permiso>();
            UsuarioPerfil = new HashSet<UsuarioPerfil>();
        }

        public byte IdPerfil { get; set; }
        public string Perfil1 { get; set; }
        public string Descripcion { get; set; }
        public string LoginCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LoginModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string LoginEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public virtual ICollection<Permiso> Permiso { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; }
    }
}
