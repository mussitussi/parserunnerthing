using System;
using ParseMeToo.Infrastructure;
using System.Text.Json;

namespace ParseMeToo.Messages
{
    public class AddHandler : ICommandHandler<Add> 
    {
        public Result Handle(Add command)
        {
            var txt = command.GetType().Name + ": " + JsonSerializer.Serialize(command);
            Console.WriteLine(txt);
            return new Result { Success = false };
        }
    }
}
