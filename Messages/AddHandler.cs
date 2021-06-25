using System;
using ParseMeToo.Infrastructure;
using System.Text.Json;

namespace ParseMeToo.Messages
{
    public class AddHandler : ICommandOptionHandler<Add> 
    {
        public IResult Handle(Add add)
        {
            var x = JsonSerializer.Serialize(new { add });
            Console.WriteLine(x);
            return new Result { Success = false };
        }
    }

}
