using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTest
{
    public readonly TodoItem _validTodo = new TodoItem("Nova Tareda","Claudio José", DateTime.Now);
    
    [TestMethod]
    public void Dado_um_novo_todo_o_mensmo_nao_pode_ser_concluido()
    {
        Assert.AreEqual(_validTodo.Done, false);
    }
}