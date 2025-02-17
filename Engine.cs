using PJT250217;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Engine
    {
        protected bool isRunning = true;

        protected ConsoleKeyInfo keyInfo;

        public void Input()
        {
            keyInfo = Console.ReadKey();
        }

        public void Load()
        {
            // file에서 로딩
            string[] scene =
            {
                "******************",
                "*P               *",
                "*                *",
                "*                *",
                "*                *",
                "*                *",
                "*        M       *",
                "*                *",
                "*                *",
                "*                *",
                "*               G*",
                "******************",
            };


            world = new World();
        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            world.Render();
        }


        public void Run()
        {
            while (isRunning)
            {
                Input();
                Update();
                Render();
            }
        }


        public World world;
    }
}