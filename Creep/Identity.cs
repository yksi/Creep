using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Creep
{
    class Identity
    {
        private static User current_user = null;

        public static bool hasIdentity()
        {
            return Identity.current_user != null;
        }

        public static User getIdentity()
        {
            if (Identity.current_user != null)
            {
                return Identity.current_user;
            }
            return null;
        }

    }
}
