using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Composio.HttpClients.Abstract;

/// <summary>
/// Provides a configured <see cref="HttpClient"/> for the Composio API.
/// </summary>
public interface IComposioOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached client owned by this provider.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Composio client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
