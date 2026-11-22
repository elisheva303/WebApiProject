using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Entities;

namespace Service
{
    public class UserServic : IUserServic
    {
       private IUserRepository userRepository ;

        public UserServic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            return await userRepository.AddUser(user);
        }
        public User GetUser(LoginUser logInUser)
        {
            return userRepository.GetUser(logInUser);
        }
        public async Task UpdateUser(int id, User updateuser)
        {
            await userRepository.UpdateUser(id, updateuser);
        }
    }
}
