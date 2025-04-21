using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVideoShop
{
    public enum AccountRole { user, admin }

    public class Account
    {
        public Account() { }
        public Account(string username, AccountRole role)
        {
            Username = username;
            Role = role;
        }

        public string Username { get; set; }
        public AccountRole Role { get; set; }
    }
}
