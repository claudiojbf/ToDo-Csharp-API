namespace Todo.Shared.Commands.Contracts;

public interface ICommand
{
    public bool Validate();
}