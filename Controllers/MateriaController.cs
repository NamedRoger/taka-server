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
    public class MateriaController : ControllerBase
    {
        private readonly takaContext context;

        public MateriaController(takaContext context)
        {
            this.context = context;
        }

        // GET: api/Materia
        [HttpGet]
        public async Task<IEnumerable<Materia>> Get()
        {
            var materias = await context.Materias.Where(m => m.Activo).ToListAsync();
            return materias;
        }

        // GET: api/Materia/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Materia
        [HttpPost]
        public async Task<ActionResult<Materia>> Post([FromBody] Materia materia)
        {
            try{
                materia.Codigo = Utility.GenerateCode(materia.Nombre,"mat");
                await context.Materias.AddAsync(materia);
                await context.SaveChangesAsync();

                return Ok(materia);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Materia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Materia materia)
        {
            try{
                var foundMateria = await context.Materias.FindAsync(id);
                if(foundMateria == null) return NotFound("No se encontró la materia");

                foundMateria.Codigo = Utility.GenerateCode(materia.Nombre,"mat");
                foundMateria.Nombre = materia.Nombre.Trim();
                await context.SaveChangesAsync();
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Materia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var foundMateria = await context.Materias.FindAsync(id);
                if(foundMateria == null) return NotFound("No se encontró la materia");
                
                foundMateria.Activo = false;
                await context.SaveChangesAsync();

                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
