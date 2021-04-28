using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models;

namespace server.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly takaContext context;

        public EspecialidadController(takaContext context)
        {
            this.context = context;
        }

        // GET: api/Especialidad
        [HttpGet]
        public async Task<IEnumerable<Especialidad>> Get()
        {
            var epspecialidades = await context.Especialidades.Where(e => e.Activo).ToListAsync();
            return epspecialidades;
        }

        // GET: api/Especialidad/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Especialidad
        [HttpPost]
        public async Task<ActionResult<Especialidad>> Post([FromBody] Especialidad especialidad)
        {
            try
            {
                especialidad.Codigo =  Utility.GenerateCode(especialidad.Nombre,"esp");
                especialidad.Activo = true;
                await context.Especialidades.AddAsync(especialidad);
                await context.SaveChangesAsync();
                return Ok(especialidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Especialidad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Especialidad especialidad)
        {
            try
            {
                var foundEspecialidad = await context.Especialidades.FindAsync(id);
                if (foundEspecialidad == null) return NotFound("No se encontro con la especialidad");

                foundEspecialidad.Codigo = Utility.GenerateCode(especialidad.Nombre,"esp");
                foundEspecialidad.Nombre = especialidad.Nombre;

                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Especialidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var foundEspecialidad = await context.Especialidades.FindAsync(id);
                if (foundEspecialidad == null) return NotFound("No se encontro con la especialidad");

                foundEspecialidad.Activo = false;

                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
