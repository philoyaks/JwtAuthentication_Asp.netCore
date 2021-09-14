using Authentication_Authorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_Authorization.Services
{


    public interface IMockRepoServicee
    {
        User FindUser();
        List<User> GetAllUsers();

        User CreateUser();
    }
    public class MockRepoService : IMockRepoServicee
    {
        public User CreateUser()
        {
            throw new NotImplementedException();
        }

        public User FindUser()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
