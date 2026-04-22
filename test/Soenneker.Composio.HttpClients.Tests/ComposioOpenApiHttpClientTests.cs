using Soenneker.Composio.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Composio.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ComposioOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IComposioOpenApiHttpClient _httpclient;

    public ComposioOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IComposioOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
