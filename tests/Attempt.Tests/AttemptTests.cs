
namespace Attempt.Tests;

public class AttemptTests
{
    [Fact]
    public void Ok_Should_Succeed()
    {
        var result = Attempt<int>.Ok(42);

        Assert.True(result.Succeeded);
        Assert.False(result.Failed);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Fail_Should_Fail()
    {
        var error = new Error("failure");
        var result = Attempt<int>.Fail(error);

        Assert.False(result.Succeeded);
        Assert.True(result.Failed);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void Deconstruct_Should_Return_Value_And_Error()
    {
        var error = new Error("error");
        var result = Attempt<int>.Fail(error);

        var (value, err) = result;

        Assert.Equal(default, value);
        Assert.Equal(error, err);
    }
}