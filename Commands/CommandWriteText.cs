using System;
using System.Threading.Tasks;
using WindowsInput.Events;

namespace Thinker.Commands
{
    public class CommandWriteText : ICommands
    {
        public void Execute(string opt1)
        {
            if (opt1.StartsWith("::"))
            {
                var keys = opt1.Split("::", StringSplitOptions.RemoveEmptyEntries);
                KeyCode[] codes = new KeyCode[keys.Length];
                for(int i = 0; i < keys.Length; i++)
                    codes[i] = (KeyCode)Enum.Parse(typeof(KeyCode), keys[i]);

                Task.Run(() => WindowsInput.Simulate.Events()
                                .ClickChord(codes).Wait(1000)
                                .Invoke()).Wait();
            }
            else
                Task.Run(() => WindowsInput.Simulate.Events()
                                .Click(opt1).Wait(Math.Max(1000, 500*opt1.Length))
                                .Invoke()).Wait();
        }

    }
}
