using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Activo { get; set; } = true;
    }
}
