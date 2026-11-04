using System.Text.Json;
using Entities;




namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)
        {
            string path = "E:/WebApi/Repositories/text.txt";

            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;
        }
        public User GetUser(LoginUser loginuser)
        {
            string path = "E:/WebApi/Repositories/text.txt";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Email == loginuser.Email && user.Password == loginuser.Password)
                        return user;

                }
            }
            return null;
        }
        public void UpdateUser(int id, User updateuser)
        {

            string path = "E:/WebApi/Repositories/text.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                    break;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateuser));
                System.IO.File.WriteAllText(path, text);
            }
        }
    }

}
