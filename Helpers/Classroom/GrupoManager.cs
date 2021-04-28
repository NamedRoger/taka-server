using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Helpers.Classroom
{
    public class GrupoManager : IGrupoManager
    {
        private readonly takaContext context;

        public GrupoManager(takaContext context)
        {
            this.context = context;
        }

        public async Task<List<Clase>> ObtenerHorario(int idGrupo, int idPeriodo)
        {
            List<Clase> calses = await context.Clases.Where(c => c.IdGrupo == idGrupo && c.IdPeriodo == idPeriodo && c.Activo)
                .Include(c => c.Grupo)
                .Include(c => c.Periodo)
                .Include(c => c.Maestro)
                .Include(c => c.Materia)
                .ToListAsync();

            return calses;
        }

        public async Task ActualizarClase(int idClase, Clase clase)
        {
            var foundClass = await ObtenerClase(idClase);
            if (foundClass == null) throw new System.Exception("No se encontró la clase");
            var materia = await context.Materias.FindAsync(clase.IdMateria);

            foundClass.HoraFin = clase.HoraFin;
            foundClass.HoraInicio = clase.HoraInicio;
            foundClass.Nombre = clase.Nombre;
            foundClass.IdMateria = clase.IdMateria;
            foundClass.IdMaestro = clase.IdMaestro;

            await context.SaveChangesAsync();
        }

        public async Task<Clase> ObtenerClase(int idClase)
        {
            Clase clase = await context.Clases.FirstOrDefaultAsync(c => c.Activo && c.IdClase == idClase); 
            return clase;
        }
        public async Task AgregarClase(int idGrupo, int idPeriodo, Clase clase)
        {
            var materia = await context.Materias.FindAsync(clase.IdMateria);
            var grupo = await ObtenerGrupo(idGrupo);
            var periodo = await ObtenerPeriodo(idPeriodo);

            if(materia == null) throw new System.Exception("No existe la materia");
            if(grupo == null) throw new System.Exception("No existe el grupo");
            if(periodo == null) throw new System.Exception("No existe el periodo");

            clase.Nombre = materia.Nombre;

            await context.Clases.AddAsync(clase);
            await context.SaveChangesAsync();
        }

        public async Task DesactivarClase(Clase clase)
        {
            clase.Activo = false;
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExisteGrupo(int idGrupo)
        {
            return (await context.Grupos.Where(g => g.Activo && g.IdGrupo == idGrupo).FirstOrDefaultAsync()) != null;
        }

        public async Task<Grupo> ObtenerGrupo(int idGrupo)
        {
            var grupo = await context.Grupos.FirstOrDefaultAsync(g => g.Activo && g.IdGrupo == idGrupo);
            return grupo;
        }

        public async Task<List<Grupo>> ObtenerGruposAsync()
        {
            var grupos = await context.Grupos.Where(g => g.Activo)
                .Include(g => g.Especialidad)
                .ToListAsync();
            return grupos;
        }

        public async Task<Periodo> ObtenerPeriodo(int idPeriodo)
        {
            var periodo = await context.Periodos.Where(p => p.Activo).FirstOrDefaultAsync(p => p.IdPeriodo == idPeriodo);
            return periodo;
        }

        public async Task<List<Periodo>> ObtenerPeriodos()
        {
            var periodos = await context.Periodos.Where(p => p.Activo)
                .ToListAsync();
                
            return periodos;
        }
    }
}