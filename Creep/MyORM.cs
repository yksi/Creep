using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    interface MyORM
    {
        dynamic[] select();
        bool insert();
        bool delete();
        bool update();
    }
}
