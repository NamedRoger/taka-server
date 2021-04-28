using System.Threading.Tasks;
using server.Infraestructura;
using server.Models;

namespace server.Helpers.Alumno
{
    public class AlumnoManager : IAlumnoManager
    {
        public async Task AddCalification(Usuario usuario, Clase clase, TypeCalificacion typeCalificacion)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddHorario(Usuario usuario, int idGrupo ,int idPeriodo)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddToClass(Usuario usuario, Clase clase)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveToClass(Usuario usuario, Clase clase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ExistMatricula(string matricula)
        {
            throw new System.NotImplementedException();
        }
    }
}