using System;

namespace Finance_Manager
{
    public class User
    {
       public int Id { get; set; } 
       public string Username { get; set; }
       public string Password { get; set; }
       public User(int userId, string username, string password)
       {
           Id = userId;
           Username = username;
           Password = password;
       }
    }
}
