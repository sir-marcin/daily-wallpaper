using System;
using System.Timers;

namespace WalpapererConsole
{
    public class Waiter
    {
        public void Wait(float seconds)
        {
            bool waiting = true;
            Timer timer = new Timer(seconds * 1000);

            void DoSometing(Object obj, ElapsedEventArgs args)
            {
                waiting = false;
            }

            timer.Elapsed += DoSometing;
            
            timer.Start();

            while (waiting)
            {
                
            }
            
            return;
        }
    }
}