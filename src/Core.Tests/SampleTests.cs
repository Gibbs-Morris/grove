using Allure.Xunit.Attributes;


namespace Core.Tests;

/// <summary>
///     Contains unit tests for the <see cref="Sample" /> class.
/// </summary>
[AllureEpic("EE-1")]
[AllureParentSuite("Web interface")]
[AllureSuite("Essential features")]
public class SampleTests
{
    /// <summary>
    ///     Tests if the <see cref="Sample.Data" /> property returns "Hello World!".
    /// </summary>
    [Fact]
    [AllureStory("EE-11", "EE-22")]
    [AllureIssue("EE-xx")]
    [AllureDescription("This is a test description")]
    [AllureId("abcd-1234")]
    [AllureLabel("severity", "critical")]
    public void ReturnsHelloWorld()
    {
        var data = Sample.Data;
        Assert.Equal("Hello World!abc", data);
    }

    /// <summary>
    ///     Tests if a hardcoded string equals "Hello World!abc".
    /// </summary>
    [AllureStory("EE-12", "EE-22")]
    [AllureIssue("EE-yy")]
    [AllureDescription("This is a test description")]
    [AllureId("abcd-1239")]
    [AllureLabel("severity", "minor")]
    public void ReturnsHelloWorld2()
    {
        Assert.Equal("Hello World!abc", "abc");
    }
}