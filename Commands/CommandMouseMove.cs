using System;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public class CommandMouseMove : ICommands
    {
        public void Execute(string opt1)
        {
            if (opt1.Contains(";")) // mover de un punto a otro
            {
                var points = opt1.Split(';');
                var coordsInit = points[0].Split(',');
                var coordsEnd = points[1].Split(',');
                Random rnd = new Random();
                int inc = rnd.Next(3, 6);
                int initX = Convert.ToInt32(coordsInit[0]);
                int initY = Convert.ToInt32(coordsInit[1]);
                int endX = Convert.ToInt32(coordsEnd[0]);
                int endY = Convert.ToInt32(coordsEnd[1]);
                Task.Run(() => CustomMoveMouseAsync(initX, endX, initY, endY, inc)).Wait();
            }
            else
            {
                var coords = opt1.Split(',');
                if (coords.Length < 2)
                    return;
                Task.Run(() => WindowsInput.Simulate.Events()
                    .MoveTo(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])).Wait(1000)
                    .Invoke()).Wait();
            }

            //int xPos = Convert.ToInt32(coords[0]);
            //int yPos = Convert.ToInt32(coords[1]);
            //NativeWin32.POINT p = new NativeWin32.POINT(xPos, yPos);

            //NativeWin32.SetCursorPos(p.x, p.y);
        }
        async Task CustomMoveMouseAsync(int initX, int endX, int initY, int endY, int inc)
        {
            while (initX != endX || initY != endY)
            {
                if (initX < endX)
                    initX = Math.Min(endX, initX + inc);
                else
                    initX = Math.Max(endX, initX - inc);
                if (initY < endY)
                    initY = Math.Min(endY, initY + inc);
                else
                    initY = Math.Max(endY, initY - inc);
                await WindowsInput.Simulate.Events()
                    .MoveTo(initX, initY).Wait(50)
                    .Invoke();
            }
        }
    }
}
