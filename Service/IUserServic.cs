using Entities;

namespace Service
{
    //The name is unclear: write the words in full, for example IUserService
    public interface IUserServic
    {
        Task<User> AddUser(User user);
        User GetUser(LoginUser logInUser);
        Task UpdateUser(int id, User updateuser);
    }
}