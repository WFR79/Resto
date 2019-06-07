using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Waiter 
    {
        private int waiter_Number;

        private string waiter_Name;


        public string Waiter_Name { get => waiter_Name; set => waiter_Name = value; }
        public int Waiter_Number { get => waiter_Number; set => waiter_Number = value; }
    }
}
