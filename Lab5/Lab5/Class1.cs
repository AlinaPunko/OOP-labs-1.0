using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{

        class Errors : Exception
        {
            public Errors(string messeg)
            {
            Console.WriteLine("Error "+ messeg + " " + this.Message + this.HResult);
            }
        }
        class Error : Exception
        {
            public Error(string messeg)
            {
                Console.WriteLine(messeg + " " + this.HResult);
            }
        }
        class Errorin : Exception
        {
            public Errorin(string messeg)
            {
                Console.WriteLine(messeg + " " + this.Message);
            }
        }
    
}
