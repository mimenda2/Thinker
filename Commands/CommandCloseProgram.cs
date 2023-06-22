using System.Diagnostics;

namespace Thinker.Commands
{
    public class CommandCloseProgram : ICommands
    {
        public void Execute(string opt1)
        {
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName.ToUpper().Equals(opt1.ToUpper()))
                {
                    process.CloseMainWindow();
                }
            }
        }
    }
}
