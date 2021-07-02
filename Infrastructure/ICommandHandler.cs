namespace ParseMeToo.Infrastructure
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Result Handle(T command);
    }
}
