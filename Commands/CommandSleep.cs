using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public class CommandSleep : ICommands
    {
        public void Execute(string opt1)
        {
            int timeToSleep = int.Parse(opt1);
            DateTime wakeUp = DateTime.Now.AddMilliseconds(timeToSleep);
            while (DateTime.Now < wakeUp)
            {
                Thread.Sleep((int)Math.Min(1000, (wakeUp - DateTime.Now).TotalMilliseconds));
                MoveMouse();
            }
        }

        void MoveMouse()
        {
            int margin = 100;
            Random rnd = new Random();
            int x = rnd.Next(margin, (int)System.Windows.SystemParameters.PrimaryScreenWidth - margin);
            int y = rnd.Next(margin, (int)System.Windows.SystemParameters.PrimaryScreenHeight - margin);
            Task.Run(() => WindowsInput.Simulate.Events().MoveTo(x, y).Invoke()).Wait();
        }
    }
}
