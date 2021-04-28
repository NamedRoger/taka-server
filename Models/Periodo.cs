using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; } = true;
    }
}
