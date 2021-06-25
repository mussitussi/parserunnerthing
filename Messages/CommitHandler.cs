using System;
using System.Text.Json;
using ParseMeToo.Infrastructure;

namespace ParseMeToo.Messages
{

    
    public class CommitHandler : ICommandOptionHandler<Commit>
    {
        public IResult Handle(Commit commit)
        {
            var x = JsonSerializer.Serialize(new { commit });
            Console.WriteLine(x);
            return new Result { Success=true};
        }
    }
}
