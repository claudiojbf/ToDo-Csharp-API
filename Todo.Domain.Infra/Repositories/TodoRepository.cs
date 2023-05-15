using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(TodoItem item)
    {
        _context.Todos?.Add(item);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderByDescending(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderByDescending(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderByDescending(x => x.Date);
    }

    public TodoItem GetById(Guid id, string user)
    {
        return _context.Todos
            .AsNoTracking()
            .FirstOrDefault(TodoQueries.GetById(user, id));  
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, date, done))
            .OrderByDescending(x => x.Date);
    }

    public void Update(TodoItem item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }
}