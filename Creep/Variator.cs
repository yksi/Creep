using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    class Variator
    {
        public static string DB_CONNECT_DATABASE = "user1";
        public static string DB_CONNECT_HOST = "localhost";
        public static string DB_CONNECT_UID = "admin";
        public static string DB_CONNECT_PASSWORD = "admin";
        public static User Logged_In_User { get;set; }
        public static Dashboard dash;
        public static Login main;
    }
}
