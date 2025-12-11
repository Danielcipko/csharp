using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager
{
    public class LoginForm
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Username = "user1", Password = "pass1" },
            new User { Id = 2, Username = "user2", Password = "pass2" }
        };
        public User Authenticate(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
