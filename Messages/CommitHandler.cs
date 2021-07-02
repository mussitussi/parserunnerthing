using System;
using System.Text.Json;
using ParseMeToo.Infrastructure;

namespace ParseMeToo.Messages
{


    public class CommitHandler : ICommandHandler<Commit>
    {
        public IResult Handle(Commit command)
        {
            var txt = command.GetType().Name + ": " + JsonSerializer.Serialize(command);
            Console.WriteLine("Handling: " + txt);
            return new Result { Success = true };
        }
    }
}
