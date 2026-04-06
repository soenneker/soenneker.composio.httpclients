using Soenneker.Composio.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Composio.HttpClients.Tests;

[Collection("Collection")]
public sealed class ComposioOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IComposioOpenApiHttpClient _httpclient;

    public ComposioOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IComposioOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
