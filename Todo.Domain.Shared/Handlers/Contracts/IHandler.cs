using Todo.Shared.Commands.Contracts;

namespace Todo.Shared.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    public ICommandResult Handle(T command);
}