using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueriesTests
{
    private List<TodoItem> _items;

    public TodoQueriesTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "claudiojose", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "claudiojose", DateTime.Now));

    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_claudiojose()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("claudiojose"));
        Assert.AreEqual(2, result.Count());
    }
}