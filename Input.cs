using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217
{
    public class Input
    {
        private Input() { }

        static Input inputInstance;

        static public Input InputInstance()
        {
            if (inputInstance == null) { inputInstance = new Input(); }
            return inputInstance;
        }

        protected ConsoleKeyInfo keyInfo;

        public void Process()
        {
            keyInfo = Console.ReadKey();
        }

        public bool GetKeyDown(ConsoleKey key)
        {
            return (keyInfo.Key == key);
        }
    }
}
