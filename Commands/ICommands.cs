using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public interface ICommands
    {
        Task Execute(string opt1);
    }
}
