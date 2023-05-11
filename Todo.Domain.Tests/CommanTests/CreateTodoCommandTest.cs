using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTest
{
    private readonly CreateTodoCommand _invelidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Estudar","Claudio José", DateTime.Now);
    
    public CreateTodoCommandTest()
    {
        _invelidCommand.Validate();
        _validCommand.Validate();
    }
    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        Assert.AreEqual(_invelidCommand.IsValid, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}