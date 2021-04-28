using System.Threading.Tasks;
using server.Infraestructura;
using server.Models;

namespace server.Helpers.Alumno
{
    public interface IAlumnoManager
    {
        Task AddToClass(Usuario alumno, Clase clase);
        Task RemoveToClass(Usuario alumno, Clase clase);
        Task AddHorario(Usuario usuario, int idGrupo ,int idPeriodo);
        Task AddCalification(Usuario usuario, Clase clase,TypeCalificacion typeCalificacion);
        Task<bool> ExistMatricula(string matricula);
    }
}