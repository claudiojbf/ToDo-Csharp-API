using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem item)
    {
    }

    public TodoItem GetById(Guid Id, string User)
    {
        return new TodoItem("Titulo Aqui","Claudio José", DateTime.Now);
    }

    public void Update(TodoItem item)
    {
    }
}