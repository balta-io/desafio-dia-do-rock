using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Extension
{
    public class CustomUserClaims
    {
        public CustomUserClaims()
        {
            
        }
        public CustomUserClaims(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
