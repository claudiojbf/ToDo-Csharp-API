using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Shared.Commands.Contracts;
using Todo.Shared.Handlers.Contracts;

namespace Todo.Domain.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);
        
        var todo = new TodoItem(command.Title, command.User, command.Date);

        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa criada com sucesso", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(false, "Ops, parace que a tarefa está errada!", command.Notifications);
        
        var todo = _repository.GetById(command.Id, command.User);

        todo.UpdateTitle(command.Title);

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(false, "Ops, algo deu errado!", command.Notifications);
        
        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsDone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(false, "Ops, algo deu errado!", command.Notifications);
        
        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsUndone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }
}