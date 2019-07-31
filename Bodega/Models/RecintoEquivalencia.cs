using System;
using System.Collections.Generic;

namespace Bodega.Models
{
    public partial class RecintoEquivalencia
    {
        public int IdRecintoRrhh { get; set; }
        public int IdRecinto { get; set; }
        public string LoginCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LoginModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string LoginEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
