using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217
{
    public class Input
    {
        public Input() { }

        protected static ConsoleKeyInfo keyInfo;

        public static void Process()
        {
            keyInfo = Console.ReadKey();
        }

        public static bool GetKeyDown(ConsoleKey key)
        {
            return (keyInfo.Key == key);
        }
    }
}
