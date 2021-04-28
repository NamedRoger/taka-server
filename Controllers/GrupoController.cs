using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Helpers.Classroom;
using server.Models;

namespace server.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly takaContext context;
        private readonly IGrupoManager grupoManager;

        public GrupoController(takaContext context, IGrupoManager grupoManager)
        {
            this.context = context;
            this.grupoManager = grupoManager;
        }

        // GET: api/Grupo
        [HttpGet]
        public async Task<IEnumerable<Grupo>> Get()
        {
            var p = User.Identity.Name;
            var grupos = await context.Grupos.Where(g => g.Activo)
                .Include(g => g.Especialidad)
                .ToListAsync();

            return grupos;
        }

        // GET: api/Grupo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> Get(int id)
        {
            var grupo = await context.Grupos.Where(g => g.Activo)
                .Include(g => g.Especialidad)
                .FirstOrDefaultAsync(g => g.IdGrupo == id);
            if(grupo == null) return NotFound("No se encontro el grupo");
            return grupo;
        }

        // POST: api/Grupo
        [HttpPost]
        public async Task<ActionResult<Grupo>> Post([FromBody] Grupo grupo)
        {
            try{
                var especialidad = await context.Especialidades.FindAsync(grupo.IdEspecialidad);
                if(especialidad == null ) return NotFound("No se encontro la especialidad que quiere asingar");

                grupo.Codigo =  Utility.GenerateCode(grupo.Nombre,"gpo");
                grupo.Activo = true;
                
                await context.Grupos.AddAsync(grupo);
                await context.SaveChangesAsync();
                return Ok(grupo);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Grupo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Grupo grupo)
        {
            try{
                var especialidad = await context.Especialidades.FindAsync(grupo.IdEspecialidad);
                if(especialidad == null ) return NotFound("No se encontro la especialidad que quiere asingar");

                var foundGrupo = await context.Grupos.FindAsync(id);
                if(foundGrupo == null ) return NotFound("No se encontro el grupo");

                foundGrupo.Codigo = Utility.GenerateCode(grupo.Nombre,"gpo");
                foundGrupo.Nombre = grupo.Nombre;
                foundGrupo.IdEspecialidad = grupo.IdEspecialidad;
                
                await context.SaveChangesAsync();
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Grupo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var grupo = await context.Grupos.FindAsync(id);
                if(grupo == null ) return NotFound("No se encontro el grupo");

                grupo.Activo = false;
                
                await context.SaveChangesAsync();
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

    }
}
