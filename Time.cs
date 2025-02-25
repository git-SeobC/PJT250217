using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217
{
    public class Time
    {
        public static double deltaTime
        {
            get
            {
                return deltaTimeSpan.TotalMilliseconds;
            }
        }

        protected static TimeSpan deltaTimeSpan;

        protected static DateTime currentTime;
        protected static DateTime lastTime;

        public static void Update()
        {
            currentTime = DateTime.Now;
            deltaTimeSpan = currentTime - lastTime;
            lastTime = currentTime;
        }
    }
}
