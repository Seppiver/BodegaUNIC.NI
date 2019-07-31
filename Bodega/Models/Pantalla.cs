using System;
using System.Collections.Generic;

namespace Bodega.Models
{
    public partial class Pantalla
    {
        public Pantalla()
        {
            Permiso = new HashSet<Permiso>();
        }

        public int IdPantalla { get; set; }
        public int? IdPadre { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsMenu { get; set; }
        public string Tipo { get; set; }
        public string Url { get; set; }
        public byte Orden { get; set; }
        public string Abreviacion { get; set; }
        public string Icon { get; set; }
        public string LoginCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LoginModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string LoginEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public virtual ICollection<Permiso> Permiso { get; set; }
    }
}
