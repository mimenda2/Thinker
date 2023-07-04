using CommandLine;
using System;

namespace Thinker
{
    internal class ThinkerParameters
    {
        [Option("filename", HelpText = "Commands file path", Default = "", Required = false)]
        public string FileName { get; set; }

        [Option("loop", HelpText ="Infinite loop", Default = false, Required = false)]
        public bool Loop { get; set; }
        [Option("duration", HelpText = "Max duration in seconds", Default = 0, Required = false)]
        public int Duration { get; set; }

    }
}
