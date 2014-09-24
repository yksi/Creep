using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    class User : MyORM
    {
        private int ID;
        private string name;
        private string email;
        private byte role;

        public User(int __ID__)
        {
            ID = __ID__;
        }

        public static User find()
        {
            return new User(0);
        }
    }
}