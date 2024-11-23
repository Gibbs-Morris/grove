using Grove.Core.Mapping;

using Microsoft.Extensions.DependencyInjection;


namespace Grove.Core.Tests.Mapping;

public class MappingRegistrationsTests
{
    [Fact]
    public void AddsMapperToServiceCollection()
    {
        ServiceCollection services = new();
        services.AddMapper<int, string, MockMapper>();
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        IMapper<int, string>? mapper = serviceProvider.GetService<IMapper<int, string>>();
        Assert.NotNull(mapper);
        Assert.IsType<MockMapper>(mapper);
    }

    [Fact]
    public void AddsIEnumerableMapperToServiceCollection()
    {
        ServiceCollection services = new();
        services.AddMapper<int, string, MockMapper>();
        services.AddIEnumerableMapper();
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        IEnumerableMapper<int, string>? mapper = serviceProvider.GetService<IEnumerableMapper<int, string>>();
        Assert.NotNull(mapper);
        Assert.IsType<EnumerableMapper<int, string>>(mapper);
    }

    [Fact]
    public void AddsIAsyncEnumerableMapperToServiceCollection()
    {
        ServiceCollection services = new();
        services.AddMapper<int, string, MockMapper>();
        services.AddIAsyncEnumerableMapper();
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        IAsyncEnumerableMapper<int, string>? mapper = serviceProvider.GetService<IAsyncEnumerableMapper<int, string>>();
        Assert.NotNull(mapper);
        Assert.IsType<AsyncEnumerableMapper<int, string>>(mapper);
    }

    private class MockMapper : IMapper<int, string>
    {
        public string Map(
            int source
        ) =>
            source.ToString();
    }
}