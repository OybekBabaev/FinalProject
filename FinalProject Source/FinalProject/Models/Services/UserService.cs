using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Models.Services
{
    public class UserService
    {
        private BloggingContext context;

        public UserService(BloggingContext ctx) => context = ctx;

        public IEnumerable<User> GetUsers() => context.Users;

        public User GetUserById(long? id) => context.Users.FirstOrDefault(u => u.Id == id);

        public User GetUserByUsername(string username) =>
            context.Users.FirstOrDefault(u => u.Username == username);

        public void SaveUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
