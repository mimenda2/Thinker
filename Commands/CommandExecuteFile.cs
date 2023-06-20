using System.Diagnostics;

namespace Thinker.Commands
{
    public class CommandExecuteFile : ICommands
    {
        public void Execute(string opt1)
        {
            try
            {
                var p = new Process();
                string arguments = "";
                int paramIndex = opt1.IndexOf("-");

                if (paramIndex > 0)
                {
                    arguments = opt1.Substring(paramIndex);
                    opt1 = opt1.Substring(0, paramIndex);
                }
                p.StartInfo = new ProcessStartInfo(@opt1)
                {
                    UseShellExecute = true,
                    Arguments = arguments
                };
                p.Start();
            }
            catch
            {
                Process.Start(@opt1);
            }
        }

    }
}
