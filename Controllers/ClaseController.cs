using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly takaContext context;

        public ClaseController(takaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("periodo/{idPeriodo}/alumno/{idAlumno}")]
        public async Task<IEnumerable<Clase>> GetGetClasesAlumno(int idPeriodo, int idAlumno){
            var clases = await context.ClaseAlumnos.Where(ca => ca.IdAlumno == idAlumno && ca.Clase.Periodo.IdPeriodo == idPeriodo)
            .Include(c => c.Alumno)
            .Include(ca => ca.Clase)
            .Select(c => new Clase{
                IdClase = c.IdClase,
                Grupo = c.Clase.Grupo,
                Materia = c.Clase.Materia,
                Nombre = c.Clase.Nombre,
                Periodo = c.Clase.Periodo,
                Maestro = c.Clase.Maestro,
            })
            .ToListAsync();
            return clases;
        }

        [HttpGet]
        [Route("periodo/{idPeriodo}/alumno/{idAlumno}/clase/{idClase}")]
        public async Task<Clase> GetGetClaseAlumno(int idPeriodo, int idAlumno,int idClase){
            var clase = await context.Clases.Where(c => c.IdPeriodo == idPeriodo)
                .Include(c => c.ClaseAlumnos.Where(ca => ca.Alumno.IdUsuario == idAlumno))
                .Include(c => c.Grupo)
                .Include(c => c.Maestro)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync();
            return clase;
        }
    }
}
