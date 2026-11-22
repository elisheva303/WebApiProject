using Entities;

namespace Service
{
    public interface IUserServic
    {
        Task<User> AddUser(User user);
        User GetUser(LoginUser logInUser);
        Task UpdateUser(int id, User updateuser);
    }
}