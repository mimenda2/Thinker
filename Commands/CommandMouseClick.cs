using System.Threading.Tasks;
using WindowsInput.Events;

namespace Thinker.Commands
{
    public class CommandMouseClick : ICommands
    {
        public void Execute(string opt1)
        {
            switch (opt1)
            {
                case "0":
                    Task.Run(() => WindowsInput.Simulate.Events()
                        .Click(ButtonCode.Left)
                        .Invoke()).Wait();
                break;
                case "1":
                    Task.Run(() => WindowsInput.Simulate.Events()
                        .DoubleClick(ButtonCode.Left)
                        .Invoke()).Wait();
                    break;
                case "2":
                    Task.Run(() => WindowsInput.Simulate.Events()
                        .DoubleClick(ButtonCode.Right)
                        .Invoke()).Wait();
                    break;
            }
        }
    }
}
