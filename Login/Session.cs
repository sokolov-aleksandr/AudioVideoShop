using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVideoShop
{
    public static class Session
    {   
        public static Account CurrentUser { get; private set; }

        public static void CreateSession(Account user)
        {
            CurrentUser = user;
        }

        public static void CloseSession()
        {
            CurrentUser = null;
        }
    }
}
