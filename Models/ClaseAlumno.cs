using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public class ClaseAlumno
    {
        public int IdClase { get; set; }
        public Clase Clase {get;set;}
        public int IdAlumno { get; set; }
        public Usuario Alumno {get;set;}
        public double? Parcial1 { get; set; } = 0;
        public double? Parcial2 { get; set; } = 0;
        public double? Parcial3 { get; set; } = 0;
        public double Calificacion {get;set;} = 0;
    }
}
