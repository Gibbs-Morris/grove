using Allure.Xunit.Attributes;


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
    [AllureStory("EE-11", "EE-22")]
    [AllureIssue("EE-xx")]
    [AllureEpic("EE-1")]
    [AllureDescription("This is a test description")]
    [AllureParentSuite("Web interface")]
    [AllureSuite("Essential features")]
    public void ReturnsHelloWorld()
    {
        var data = Sample.Data;
        Assert.Equal("Hello World!abc", data);
    }
}