using System;
using System.Text.Json;
using ParseMeToo.Infrastructure;
using ParseMeToo.Messages;

namespace ParseMeToo
{
    class Program
    {
        static void Main(string[] args)
        {
            var grr = new CommandParseRunnerThing();

            grr.Add(new CommitHandler());
            grr.Add(new AddHandler());

            Result result = grr.RunMe(args);

            Console.WriteLine($"result = {JsonSerializer.Serialize(result)}");
        }
    }
}
