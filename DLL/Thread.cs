using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLL
{
    public class Thread
    {
        public static void getMyName() { }

        public Thread Create() {
            Thread tr = new Thread();
            return tr;
        }
    }
}
