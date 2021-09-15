using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_Authorization.Model
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }

        public String Password { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Token { get; set; } = "";
    }
}
