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
        Mock<IMapper<int, string>> mockMapper = new Mock<IMapper<int, string>>();
        mockMapper.Setup(m => m.Map(It.IsAny<int>())).Returns<int>(i => i.ToString());
        EnumerableMapper<int, string> enumerableMapper = new EnumerableMapper<int, string>(mockMapper.Object);
        List<int> input = new List<int>
        {
            1,
            2,
            3,
        };

        // Act
        IEnumerable<string> result = enumerableMapper.Map(input);

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
        Mock<IMapper<int, string>> mockMapper = new Mock<IMapper<int, string>>();
        EnumerableMapper<int, string> enumerableMapper = new EnumerableMapper<int, string>(mockMapper.Object);
        List<int> input = new List<int>();

        // Act
        IEnumerable<string> result = enumerableMapper.Map(input);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void MapsCollectionWithNullElements()
    {
        // Arrange
        Mock<IMapper<int?, string>> mockMapper = new Mock<IMapper<int?, string>>();
        mockMapper.Setup(m => m.Map(It.IsAny<int?>())).Returns<int?>(i => i?.ToString() ?? "null");
        EnumerableMapper<int?, string> enumerableMapper = new EnumerableMapper<int?, string>(mockMapper.Object);
        List<int?> input = new List<int?>
        {
            1,
            null,
            3,
        };

        // Act
        IEnumerable<string> result = enumerableMapper.Map(input);

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