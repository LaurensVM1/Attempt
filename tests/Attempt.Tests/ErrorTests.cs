namespace Attempt.Tests;

public class ErrorTests
{
    [Fact]
    public void Error_From_Message_Should_Set_Message()
    {
        var error = new Error("something went wrong");

        Assert.Equal("something went wrong", error.Message);
        Assert.Null(error.Exception);
    }

    [Fact]
    public void Error_From_Exception_Should_Set_Message()
    {
        var ex = new InvalidOperationException("invalid");
        var error = new Error(ex.Message, ex);

        Assert.Equal("invalid", error.Message);
        Assert.Equal(ex, error.Exception);
    }
}
