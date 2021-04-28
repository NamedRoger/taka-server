using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Authorize(Roles = "Administrador,Maestro,Alumno")]
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly takaContext context;

        public PeriodoController(takaContext context)
        {
            this.context = context;
        }

        // GET: api/Periodo
        [HttpGet]
        public async Task<IEnumerable<Periodo>> Get()
        {
            var periodos = await context.Periodos.Where(p => p.Activo).ToListAsync();
            return periodos;
        }

        // GET: api/Periodo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Periodo
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Periodo>> Post([FromBody] Periodo periodo)
        {
            try
            {
                await context.Periodos.AddAsync(periodo);
                await context.SaveChangesAsync();
                return Ok(periodo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Periodo/5
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Periodo periodo)
        {
            try{
                var foundPeriod = await context.Periodos.FindAsync(id);
                if(foundPeriod == null) return NotFound("No se econctro el periodo");

                foundPeriod.FechaFin = periodo.FechaFin;
                foundPeriod.FechaInicio = periodo.FechaInicio;
                foundPeriod.Nombre = periodo.Nombre;

                await context.SaveChangesAsync();
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Periodo/5
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var foundPeriod = await context.Periodos.FindAsync(id);
                foundPeriod.Activo = false;
                await context.SaveChangesAsync();
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
