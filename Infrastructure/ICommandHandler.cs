namespace ParseMeToo.Infrastructure
{
    public interface ICommandHandler<T> where T : ICommand
    {
        IResult Handle(T command);
    }
    
    public interface IResult {}

    public class Result : IResult
    {
        public bool Success { get; set; }
    }
}
