using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        User GetUser(LoginUser loginuser);
        Task UpdateUser(int id, User updateuser);
    }
}