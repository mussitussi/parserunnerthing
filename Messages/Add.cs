using CommandLine;
using ParseMeToo.Infrastructure;

namespace ParseMeToo.Messages
{
    [Verb("add", HelpText = "add stuff")]
    public class Add : ICommand
    {
        [Option('n', "dry-run", HelpText = "ok computer")]
        public bool DryRun { get; set; }
    }
}
