using System.Collections.Generic;

using Grove.Core.Mapping;

using Moq;


namespace Grove.Core.Tests;

public class EnumerableMapperTests
{
    [Fact]
    public void MapsCollectionCorrectly()
    {
        // Arrange
        var mockMapper = new Mock<IMapper<int, string>>();
        mockMapper.Setup(m => m.Map(It.IsAny<int>())).Returns<int>(i => i.ToString());
        var enumerableMapper = new EnumerableMapper<int, string>(mockMapper.Object);
        var input = new List<int>
        {
            1,
            2,
            3,
        };

        // Act
        var result = enumerableMapper.Map(input);

        // Assert
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
    public void MapsEmptyCollection()
    {
        // Arrange
        var mockMapper = new Mock<IMapper<int, string>>();
        var enumerableMapper = new EnumerableMapper<int, string>(mockMapper.Object);
        var input = new List<int>();

        // Act
        var result = enumerableMapper.Map(input);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void MapsCollectionWithNullElements()
    {
        // Arrange
        var mockMapper = new Mock<IMapper<int?, string>>();
        mockMapper.Setup(m => m.Map(It.IsAny<int?>())).Returns<int?>(i => i?.ToString() ?? "null");
        var enumerableMapper = new EnumerableMapper<int?, string>(mockMapper.Object);
        var input = new List<int?>
        {
            1,
            null,
            3,
        };

        // Act
        var result = enumerableMapper.Map(input);

        // Assert
        Assert.Equal(
            new List<string>
            {
                "1",
                "null",
                "3",
            },
            result);
    }
}