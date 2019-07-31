using System;
using System.Collections.Generic;

namespace Bodega.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Permiso = new HashSet<Permiso>();
            UsuarioPerfil = new HashSet<UsuarioPerfil>();
        }

        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public int CodigoInterno { get; set; }
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
