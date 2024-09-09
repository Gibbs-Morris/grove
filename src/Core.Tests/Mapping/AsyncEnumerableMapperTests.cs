using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Grove.Core.Mapping;

using Moq;


namespace Grove.Core.Tests.Mapping;

public class AsyncEnumerableMapperTests
{
    [Fact]
    public async Task MapsAsyncCollectionCorrectlyAsync()
    {
        Mock<IMapper<int, string>> mockMapper = new();
        mockMapper.Setup(m => m.Map(It.IsAny<int>())).Returns<int>(i => i.ToString());
        AsyncEnumerableMapper<int, string> asyncEnumerableMapper = new(mockMapper.Object);
        IAsyncEnumerable<int> input = GetAsyncEnumerableAsync(
            new List<int>
            {
                1,
                2,
                3,
            });
        List<string> result = await asyncEnumerableMapper.Map(input).ToListAsync();
        Assert.Equal(
            new List<string>
            {
                "1",
                "2",
                "3",
            },
            result);
    }

    [Fact]
    public async Task MapsEmptyAsyncCollectionAsync()
    {
        Mock<IMapper<int, string>> mockMapper = new();
        AsyncEnumerableMapper<int, string> asyncEnumerableMapper = new(mockMapper.Object);
        IAsyncEnumerable<int> input = GetAsyncEnumerableAsync(new List<int>());
        List<string> result = await asyncEnumerableMapper.Map(input).ToListAsync();
        Assert.Empty(result);
    }

    [Fact]
    public async Task MapsAsyncCollectionWithNullElementsAsync()
    {
        Mock<IMapper<int?, string>> mockMapper = new();
        mockMapper.Setup(m => m.Map(It.IsAny<int?>())).Returns<int?>(i => i?.ToString() ?? "null");
        AsyncEnumerableMapper<int?, string> asyncEnumerableMapper = new(mockMapper.Object);
        IAsyncEnumerable<int?> input = GetAsyncEnumerableAsync(
            new List<int?>
            {
                1,
                null,
                3,
            });
        List<string> result = await asyncEnumerableMapper.Map(input).ToListAsync();
        Assert.Equal(
            new List<string>
            {
                "1",
                "null",
                "3",
            },
            result);
    }

    /// <summary>
    ///     Asynchronously enumerates a collection of items.
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection.</typeparam>
    /// <param name="items">The collection of items to enumerate.</param>
    /// <returns>An asynchronous enumerable of the items.</returns>
    private static async IAsyncEnumerable<T> GetAsyncEnumerableAsync<T>(
        IEnumerable<T> items
    )
    {
        ArgumentNullException.ThrowIfNull(items);
        foreach (T item in items)
        {
            yield return item;
            await Task.Yield();
        }
    }
}