using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    interface MyORM
    {
        //Object[] select();
        bool save();
        bool delete();
        Object update();
    }
}
