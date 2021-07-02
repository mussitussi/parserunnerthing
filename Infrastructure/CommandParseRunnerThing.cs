using System;
using CommandLine;
using System.Collections.Generic;
using System.Linq;

namespace ParseMeToo.Infrastructure
{
    public class CommandParseRunnerThing
    {
        private Dictionary<Type, dynamic> _commandToHandlerMap = new Dictionary<Type, dynamic>();

        public void Add<T>(ICommandHandler<T> handler) where T : ICommand
        {
            _commandToHandlerMap[typeof(T)] = handler;
        }

        public IResult RunMe(params string[] args)
        {
            Type[] ts = _commandToHandlerMap.Keys.ToArray();

            var parserResult = Parser.Default.ParseArguments(args, ts);
            var result = parserResult
                .MapResult(parsedFunc: x => _HandleParsed(x),
                           notParsedFunc: x => _HandleNotParsedFunc(x));

            return result;
        }

        private IResult _HandleNotParsedFunc(IEnumerable<Error> x)
        {
            return new Result {Success = false };
        }

        private IResult _HandleParsed(dynamic x)
        {
            var handler = _commandToHandlerMap[x.GetType()];
            return handler.Handle(x);
        }
    }
}