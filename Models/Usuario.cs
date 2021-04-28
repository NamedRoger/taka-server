using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace server.Models
{
    public class Usuario
    {
        public int IdUsuario {get;set;}
        public string UserName {get;set;}
        public string UserNameNormalize {get;set;}
        public string Password {get;set;}
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Curp { get; set; }
        public bool Activo { get; set; } = true;
        public string Matricula { get; set; }
        public int IdRole {get;set;}
        public Role Role {get;set;}

        public ICollection<Clase> Clases {get;set;}
        public List<ClaseAlumno> ClaseAlumnos {get;set;}
    }
}
