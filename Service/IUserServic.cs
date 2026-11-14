using Entities;

namespace Service
{
        //IUserServic looks like a typo: IUserService is clearer
    public interface IUserServic
    {
        User AddUser(User user);
        User GetUser(LoginUser logInUser);
        void UpdateUser(int id, User updateuser);
    }
}