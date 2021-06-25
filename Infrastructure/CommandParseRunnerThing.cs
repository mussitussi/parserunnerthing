using System;
using CommandLine;
using System.Collections.Generic;
using System.Linq;

namespace ParseMeToo.Infrastructure
{
    public class CommandParseRunnerThing
    {
        private Dictionary<Type, dynamic> _cmdToCmdHandler = new Dictionary<Type, dynamic>();

        public void Add<T>(ICommandOptionHandler<T> handler) where T : ICommandOption
        {
            Type cmdType = typeof(T);
            _cmdToCmdHandler[cmdType] = (dynamic) handler;
        }

        public IResult RunMe(params string[] args)
        {
            Type[] ts = _cmdToCmdHandler.Keys.ToArray();

            var parser = Parser.Default.ParseArguments(args, ts);
            parser.WithParsed<dynamic>(x => _cmdToCmdHandler[x.GetType()].Handle(x));
            parser.WithNotParsed(x => Console.WriteLine("hej mor der var en fejl"));
            return null;
        }

    }
}
