using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTest
{
    private readonly CreateTodoCommand _invelidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Estudar","Claudio José", DateTime.Now);
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());


    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        var result = (GenericCommandResult)_handler.Handle(_invelidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Dado_um_command_valido_deve_criar_a_tarefa()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}