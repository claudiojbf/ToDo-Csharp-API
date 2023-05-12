using Flunt.Notifications;
using Flunt.Validations;
using Todo.Shared.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand()
    {
        Title = "";
        User = "";
    }

    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Title, 3, "Title", "Por favor, descreva melhor essa tarefa")
                .IsGreaterOrEqualsThan(User, 6, "User", "Usuário Inválido")
                .AreEquals(Id.ToString().Length, 36, "Id", "Tarefa Inexistente")
        );
    }
}