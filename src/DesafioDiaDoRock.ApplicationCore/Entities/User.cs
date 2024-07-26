using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Roles { get; set; }

        public User(string name, string email, string password, string roles)
        {
            Name = name;
            Email = email;
            Password = password;
            Roles = roles;
        }
    }

}
