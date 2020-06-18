using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Timer
    {
        IApp app;

        public Timer(IApp app)
        {
            this.app = app;
        }

        public void Start()
        {
            // ...
            app.TimeFinished();
        }
    }
}
