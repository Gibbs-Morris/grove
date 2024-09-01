using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Grove.Core.Mapping;

using Moq;


namespace Grove.Core.Tests.Mapping;

public class AsyncEnumerableMapperTests
{
    [Fact]
    public async Task MapsAsyncCollectionCorrectly()
    {
        var mockMapper = new Mock<IMapper<int, string>>();
        mockMapper.Setup(m => m.Map(It.IsAny<int>())).Returns<int>(i => i.ToString());
        var asyncEnumerableMapper = new AsyncEnumerableMapper<int, string>(mockMapper.Object);
        var input = GetAsyncEnumerable(
            new List<int>
            {
                1,
                2,
                3,
            });
        var result = await asyncEnumerableMapper.Map(input).ToListAsync();
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
    public async Task MapsEmptyAsyncCollection()
    {
        var mockMapper = new Mock<IMapper<int, string>>();
        var asyncEnumerableMapper = new AsyncEnumerableMapper<int, string>(mockMapper.Object);
        var input = GetAsyncEnumerable(new List<int>());
        var result = await asyncEnumerableMapper.Map(input).ToListAsync();
        Assert.Empty(result);
    }

    [Fact]
    public async Task MapsAsyncCollectionWithNullElements()
    {
        var mockMapper = new Mock<IMapper<int?, string>>();
        mockMapper.Setup(m => m.Map(It.IsAny<int?>())).Returns<int?>(i => i?.ToString() ?? "null");
        var asyncEnumerableMapper = new AsyncEnumerableMapper<int?, string>(mockMapper.Object);
        var input = GetAsyncEnumerable(
            new List<int?>
            {
                1,
                null,
                3,
            });
        var result = await asyncEnumerableMapper.Map(input).ToListAsync();
        Assert.Equal(
            new List<string>
            {
                "1",
                "null",
                "3",
            },
            result);
    }

    private async IAsyncEnumerable<T> GetAsyncEnumerable<T>(
        IEnumerable<T> items
    )
    {
        foreach (var item in items)
        {
            yield return item;
            await Task.Yield();
        }
    }
}