namespace Core.Tests;

/// <summary>
///     Contains unit tests for the <see cref="Sample" /> class.
/// </summary>
public class SampleTests
{
    /// <summary>
    ///     Tests if the <see cref="Sample.Data" /> property returns "Hello World!".
    /// </summary>
    [Fact]
    public void ReturnsHelloWorld()
    {
        var data = Sample.Data;
        Assert.Equal("Hello World!", data);
    }
}