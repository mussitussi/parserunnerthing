using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace ParseMeToo.Infrastructure
{
    public class CommandParseRunnerThing
    {
        private Dictionary<Type, dynamic> _commandToHandlerMap = new Dictionary<Type, dynamic>();

        public void Add<T>(ICommandHandler<T> handler) where T : ICommand
        {
            _commandToHandlerMap[typeof(T)] = handler;
        }

        public Result RunMe(params string[] args)
        {
            Type[] ts = _commandToHandlerMap.Keys.ToArray();

            var parserResult = Parser.Default.ParseArguments(args, ts);
            var result = parserResult
                .MapResult(x => _HandleParsed(x),
                           x => _HandleNotParsedFunc(x));

            return result;
        }

        private Result _HandleParsed(dynamic command)
        {
            var handler = _commandToHandlerMap[command.GetType()];
            return handler.Handle(command);
        }

        private static Result _HandleNotParsedFunc(IEnumerable<Error> x)
        {
            return new Result { Success = false };
        }
    }
}