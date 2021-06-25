﻿using ParseMeToo.Infrastructure;
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
            var result = grr.RunMe(args);
        }
    }
}
