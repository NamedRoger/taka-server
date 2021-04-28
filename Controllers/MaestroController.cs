using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers.User;
using server.Models;

namespace server.Controllers
{
    [Authorize(Roles = "Administrador,Maestro")]
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly takaContext context;
        private IUserManager<Usuario, int> userManager;

        public MaestroController(takaContext context, IUserManager<Usuario, int> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetMaestrosAsync()
        {
            var maestros = await context.Usuarios.Include(u => u.Role)
                .Where(u => u.Role.Nombre == "Maestro" && u.Activo)
                .ToListAsync();

            maestros.ForEach(m => m.Password = null);
            return maestros;
        }

        [HttpGet]
        [Route("{idMaestro}/periodo/{idPeriodo}/clases")]
        public async Task<IEnumerable<Clase>> ObtenerClases(int idMaestro, int idPeriodo)
        {
            var clases = await context.Clases.Where(c => c.IdMaestro == idMaestro && c.IdPeriodo == idPeriodo)
                .Include(c => c.Periodo)
                .Include(c => c.Maestro)
                .Include(c => c.Grupo)
                .Include(c => c.Materia)
                .ToListAsync();

            return clases;
        }

        [HttpGet]
        [Route("{idMaestro}/periodo/{idPeriodo}/clases/{idClase}")]
        public async Task<ActionResult<Clase>> ObtenerClase(int idMaestro, int idPeriodo, int idClase)
        {
            var userName = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var usuario = await userManager.FindUser(userName);

            if(usuario.IdUsuario != idMaestro) return Unauthorized();

            var clase = await context.Clases.Where(c => c.Activo)
                .Include(c => c.Alumnos)
                .Select(c => new Clase
                {
                    IdClase = c.IdClase,
                    IdMaestro = c.IdMaestro,
                    ClaseAlumnos = c.ClaseAlumnos.Select(ca => new ClaseAlumno
                    {
                        Alumno = new Usuario
                        {
                            ApellidoMaterno = ca.Alumno.ApellidoMaterno,
                            ApellidoPaterno = ca.Alumno.ApellidoPaterno,
                            Nombre = ca.Alumno.Nombre,
                            Matricula = ca.Alumno.Matricula,
                            Curp = ca.Alumno.Curp
                        },
                        Calificacion = ca.Calificacion,
                        Parcial1 = ca.Parcial1,
                        Parcial2 = ca.Parcial2,
                        Parcial3 = ca.Parcial3
                    }).ToList(),
                    Alumnos = c.Alumnos.Select(a => new Usuario
                    {
                        Curp = a.Curp,
                        ApellidoMaterno = a.ApellidoMaterno,
                        ApellidoPaterno = a.ApellidoPaterno,
                        Nombre = a.Nombre,
                        Matricula = a.Matricula,
                        UserName = a.UserName
                    }).ToList()
                })
                .FirstOrDefaultAsync(c => c.IdClase == idClase);

                if(clase.IdMaestro != usuario.IdUsuario) return Unauthorized();

            return clase;
        }
    }
}
