using L20250217;
using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217
{
    public class Input
    {
        public Input()
        {

        }

        protected static ConsoleKeyInfo keyInfo;

        public static void Process()
        {
            //if (Console.KeyAvailable)
            //{
            //    keyInfo = Console.ReadKey(true);
            //}
        }

        public static bool GetKeyDown(ConsoleKey key)
        {
            return (keyInfo.Key == key);
        }

        public static bool GetKeyDown(SDL.SDL_Keycode pKey)
        {
            return (Engine.Instance.myEvent.key.keysym.sym == pKey);
        }

        public static void ClearInput()
        {
            keyInfo = new ConsoleKeyInfo();
        }
    }
}
