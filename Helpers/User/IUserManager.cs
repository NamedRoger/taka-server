using System.Threading.Tasks;

namespace server.Helpers.User
{
    public interface IUserManager<TUser,TKey>
    {
        Task<TUser> FindUser(string username);
        Task AddUser(TUser user);
        Task UpdateUser(TKey key, TUser user);
        Task ChangePassword(TUser user, string password);
        Task DesactiveUser(TUser user);
    }
}