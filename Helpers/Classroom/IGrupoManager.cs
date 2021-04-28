using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Helpers.Classroom
{
    public interface IGrupoManager
    {
        Task<Periodo> ObtenerPeriodo(int idPeriodo);
        Task<List<Periodo>> ObtenerPeriodos();

        Task<Grupo> ObtenerGrupo(int idGrupo);
        Task<List<Grupo>> ObtenerGruposAsync();
        Task<bool> ExisteGrupo(int idGrupo);

        Task<List<Clase>> ObtenerHorario(int idGrupo,int idPeriodo);
        Task<Clase> ObtenerClase(int idClase);
        Task AgregarClase(int idGrupo,int idPeriodo, Clase clase);
        Task DesactivarClase(Clase clase);
        Task ActualizarClase(int idClase, Clase clase);

    }
}