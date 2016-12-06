using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            ClickManager cm = new ClickManager();

            while (true)
            {
                cm.SimulateRandomMouseMovement(10, 500);
            }
            
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
