using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public interface ICommands
    {
        void Execute(string opt1);
    }
}
