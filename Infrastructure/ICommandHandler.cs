namespace ParseMeToo.Infrastructure
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Result Handle(T command);
    }
    

    public class Result
    {
        public bool Success { get; set; }
    }
}
