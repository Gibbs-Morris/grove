namespace Core;

/// <summary>
///     A static class that provides sample data.
/// </summary>
public static class Sample
{
    /// <summary>
    ///     A constant string value containing "Hello World!".
    /// </summary>
    private const string DataValue = "Hello World!";

    /// <summary>
    ///     Gets the constant data value.
    /// </summary>
    public static string Data => DataValue + "abc";
}