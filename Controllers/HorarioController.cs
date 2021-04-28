using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers.Classroom;
using server.Models;

namespace server.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly takaContext context;
        private readonly IGrupoManager grupoManager;

        public HorarioController(takaContext context, IGrupoManager grupoManager)
        {
            this.context = context;
            this.grupoManager = grupoManager;
        }

        [HttpGet]
        [Route("grupo/{idGrupo}/periodo/{idPeriodo}/clases")]
        public async Task<IEnumerable<Clase>> ObtenerHorario(int idGrupo, int idPeriodo)
        {
            return await grupoManager.ObtenerHorario(idGrupo, idPeriodo);
            
        }

        [HttpGet("grupo/{idGrupo}/periodo/{idPeriodo}/clases/{idClase}")]
        public async Task<Clase> ObtenerClase(int idClase)
        {
            var clase = await context.Clases.Where(c => c.Activo)
                .Include(c => c.Alumnos)
                .Select(c =>new Clase{
                    IdClase = c.IdClase,
                    ClaseAlumnos = c.ClaseAlumnos.Select(ca => new ClaseAlumno{
                        Alumno = new Usuario { 
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
                    Alumnos = c.Alumnos.Select(a => new Usuario {
                        Curp = a.Curp,
                        ApellidoMaterno = a.ApellidoMaterno,
                        ApellidoPaterno = a.ApellidoPaterno,
                        Nombre = a.Nombre,
                        Matricula = a.Matricula,
                        UserName = a.UserName
                    }).ToList()
                })
                .FirstOrDefaultAsync(c => c.IdClase == idClase);

            return clase;
        }

        [HttpPost]
        [Route("grupo/{idGrupo}/periodo/{idPeriodo}/clases")]
        public async Task<ActionResult<Clase>> AgregarClase(int idGrupo, int idPeriodo, [FromBody] Clase clase)
        {
            try
            {
                await grupoManager.AgregarClase(idGrupo, idPeriodo, clase);
                return Ok(clase);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("grupo/{idGrupo}/periodo/{idPeriodo}/clases/{idClase}")]
        public async Task<IActionResult> ActualizarClase(int idGrupo, int idPeriodo, int idClase, [FromBody] Clase clase)
        {
            try
            {
                await grupoManager.ActualizarClase(idClase, clase);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("grupo/{idGrupo}/periodo/{idPeriodo}/clases/{idClase}")]
        public async Task<IActionResult> BorrarClase(int idGrupo, int idPeriodo, int idClase)
        {
            try
            {
                var clase = await grupoManager.ObtenerClase(idClase);
                await grupoManager.DesactivarClase(clase);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}