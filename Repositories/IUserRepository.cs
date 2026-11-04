using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUser(LoginUser loginuser);
        void UpdateUser(int id, User updateuser);
    }
}