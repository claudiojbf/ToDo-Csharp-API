using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    public void Create(TodoItem item);
    public void Update(TodoItem item);
}