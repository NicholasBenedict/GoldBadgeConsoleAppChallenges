using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class OutingsConsole
    {
        static void Main(string[] args)
        {
            OutingsUI outings = new OutingsUI();
            outings.Run();
        }
    }
}
