using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WindowsInput;
using System.Windows.Forms;
using System.Threading.Tasks;
using WindowsInput.Events;

namespace Thinker.Commands
{
    public class CommandMouseMove : ICommands
    {
        public async Task Execute(string opt1)
        {
            var coords = opt1.Split(',');
            if (coords.Length < 2)
                return;
            string optClick = "0";
            if (coords.Length == 3)
                optClick = coords[2];
            switch(optClick)
            {
                case "0":
                    await WindowsInput.Simulate.Events()
                        .MoveTo(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])).Wait(1000)
                        .Invoke();
                    break;
                case "1":
                    await WindowsInput.Simulate.Events()
                        .MoveTo(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])).Wait(1000)
                        .Click(ButtonCode.Left)
                        .Invoke();
                    break;
                case "2":
                    await WindowsInput.Simulate.Events()
                        .MoveTo(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])).Wait(1000)
                        .DoubleClick(ButtonCode.Left)
                        .Invoke();
                    break;
            }

            //int xPos = Convert.ToInt32(coords[0]);
            //int yPos = Convert.ToInt32(coords[1]);
            //NativeWin32.POINT p = new NativeWin32.POINT(xPos, yPos);

            //NativeWin32.SetCursorPos(p.x, p.y);
        }

    }
}
