using CommandLine;
using ParseMeToo.Infrastructure;

namespace ParseMeToo.Messages
{
    [Verb("commit", HelpText = "commit stuff")]
    public class Commit : ICommand
    {
        [Option('m', "message", Required = true)]
        public string Message { get; set; }
    }
}
