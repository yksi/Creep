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

        public static string getBodyHTMLFromString(string InnerHTML)
        {
            return "<body><style> body { font-family: Arial; } th, td { padding: 3px; border: 1px solid grey; } }</style><div>" + InnerHTML + "</div> </body>";
        }
    }
}
