[![](https://img.shields.io/nuget/v/soenneker.composio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.composio.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.composio.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.composio.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.composio.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.composio.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.composio.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.composio.httpclients/actions/workflows/codeql.yml)

# Soenneker.Composio.HttpClients

Provides a cached `HttpClient` configured for the Composio API with project API-key authentication.

## Installation

```bash
dotnet add package Soenneker.Composio.HttpClients
```

## Configuration

```json
{
  "Composio": {
    "ApiKey": "your-project-api-key"
  }
}
```

The client sends the key in `x-api-key` and uses `https://backend.composio.dev` as its base address. These defaults can be overridden with `Composio:AuthHeaderName`, `Composio:AuthHeaderValueTemplate`, and `Composio:ClientBaseUrl`. The value template must contain `{token}` when the configured API key should be inserted.

## Registration and usage

```csharp
using Soenneker.Composio.HttpClients.Abstract;
using Soenneker.Composio.HttpClients.Registrars;

services.AddComposioOpenApiHttpClientAsSingleton();

public sealed class ComposioService
{
    private readonly IComposioOpenApiHttpClient _provider;

    public ComposioService(IComposioOpenApiHttpClient provider)
    {
        _provider = provider;
    }

    public async Task<HttpResponseMessage> GetToolkits(CancellationToken cancellationToken)
    {
        HttpClient client = await _provider.Get(cancellationToken);
        return await client.GetAsync("/api/v3/toolkits", cancellationToken);
    }
}
```

`Get` returns the same cached client for the lifetime of the provider. The provider owns that client: disposing the provider removes and disposes its cache entry. Prefer the singleton registration for normal application use. The scoped registration creates an independently owned client for each scope.
