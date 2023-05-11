using Flunt.Notifications;
using Flunt.Validations;
using Todo.Shared.Commands.Contracts;

namespace Todo.Domain.Commands;

public abstract class MarkTodo : Notifiable<Notification>, ICommand
{
    public MarkTodo(){ }

    public MarkTodo(Guid id, string? user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string? User { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .AreEquals(Id.ToString().Length, 36, "Id", "Usuário Inválido")
                .IsGreaterOrEqualsThan(User, 6, "User", "Usuário Inválido")
        );
    }
}