using Entities;

namespace Service
{
    public interface IUserServic
    {
        User AddUser(User user);
        User GetUser(LoginUser logInUser);
        void UpdateUser(int id, User updateuser);
    }
}