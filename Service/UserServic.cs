using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Entities;

namespace Service
{
    public class UserServic : IUserServic
    {
        IUserRepository userRepository ;

        public UserServic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return userRepository.AddUser(user);
        }
        public User GetUser(LoginUser logInUser)
        {
            return userRepository.GetUser(logInUser);
        }
        public void UpdateUser(int id, User updateuser)
        {
            userRepository.UpdateUser(id, updateuser);
        }
    }
}
