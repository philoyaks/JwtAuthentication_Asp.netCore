using Authentication_Authorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_Authorization.Services
{


    public interface IMockRepoService
    {
        User FindUser(string Username, string Password);
        List<User> GetAllUsers();

        User CreateUser(User user);
    }


    public class MockRepoService : IMockRepoService
    {
        public List<User> users { get; set; }




        public MockRepoService()
        {
            users = new List<User> { };
        }
        public User CreateUser(User user)
        {
            users.Add(user);
            return user;
        }

        public User FindUser(string Username, string Password)
        {
            if (users.Count() < 1)
            {
                return null;
            }
            var result = users.Find(x => x.Username == Username && x.Password == Password);
            if (result is null)
            {
                return new User();
            }

            return result;

        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
