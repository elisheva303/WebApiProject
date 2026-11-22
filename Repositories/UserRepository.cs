using System.Text.Json;
using Entities;




namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        StoreDBContext _context;
        public UserRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public User GetUser(LoginUser loginuser)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == loginuser.Email && u.Password == loginuser.Password);
            return user;
        }
        public async Task UpdateUser(int id, User updateuser)
        {
            _context.Users.Update(updateuser);
            await _context.SaveChangesAsync();
        }
    }

}
