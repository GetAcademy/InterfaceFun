using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class App : IApp
    {
        Timer b;

        public void Run()
        {
            var timer = new Timer(this);
            timer.Start();
        }

        public void TimeFinished()
        {
            
        }
    }
}
