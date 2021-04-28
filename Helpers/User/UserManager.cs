using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Helpers.User
{
    public class UserManager : IUserManager<Usuario, int>
    {
        private readonly takaContext context;

        public UserManager(takaContext context)
        {
            this.context = context;
        }

        public async Task AddUser(Usuario user)
        {
            if((await FindUser(user.UserName)) != null) throw new System.Exception("Ya existe el usuario");
            var role = await FindRole(user.IdRole);
            user.UserName = user.UserName.Trim();
            user.Role = role;
            user.Password = HashPassword(user.Password);
            user.UserNameNormalize = user.UserName.ToUpper().Trim();
            user.Activo = true;

            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task ChangePassword(Usuario user, string password)
        {
            user.Password = HashPassword(password);
            await context.SaveChangesAsync();
        }

        public async Task DesactiveUser(Usuario usuario)
        {
            var foundUser = await FindUser(usuario.UserName);
            if(foundUser == null) throw new System.Exception("No se encontro el usuario");
            foundUser.Activo = false;
            await context.SaveChangesAsync();
        }

        public async Task<Usuario> FindUser(string username)
        {
            username = username.ToUpper();
            var usuario = await context.Usuarios.Where(u => u.Activo && u.UserNameNormalize == username)
            .Include(u => u.Role)
            .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task UpdateUser(int key, Usuario user)
        {
            var foundUser = await context.Usuarios.FindAsync(key);
            if(!(foundUser.UserNameNormalize == user.UserName.ToUpper().Trim())){
                if((await FindUser(user.UserName)) != null) throw new System.Exception("Ya existe el usuario");   
            }
            
            foundUser.UserName = user.UserName;
            foundUser.UserNameNormalize = user.UserName.ToUpper().Trim();
            foundUser.ApellidoMaterno = user.ApellidoMaterno;
            foundUser.ApellidoPaterno = user.ApellidoPaterno;
            foundUser.Curp = user.Curp;
            foundUser.Matricula = user.Matricula;
            foundUser.Nombre = user.Nombre;

            await context.SaveChangesAsync();
        }

        private async Task<Role> FindRole(int id){
            var role =  await context.Roles.FindAsync(id);
            if(role == null) throw new System.Exception("No existe el rol");
            return role;
        }  

        private string HashPassword(string password){
            return BCrypt.Net.BCrypt.HashPassword(password);
        } 
    }
}