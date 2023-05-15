using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    public void Create(TodoItem item);

    public void Update(TodoItem item);
    
    public TodoItem GetById(Guid Id, string User);

    public IEnumerable<TodoItem> GetAll(string user);
    
    public IEnumerable<TodoItem> GetAllDone(string user);

    public IEnumerable<TodoItem> GetAllUndone(string user);

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done); 
}