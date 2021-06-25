namespace ParseMeToo.Infrastructure
{
    public interface ICommandOptionHandler<T> where T : ICommandOption
    {
        IResult Handle(T command);
    }
    
    public interface IResult {}

    public class Result : IResult
    {
        public bool Success { get; set; }
    }
}
