using System;
using Microsoft.JSInterop;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Append.Blazor.WebShare;

public class WebShareService : IAsyncDisposable, IWebShareService
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public WebShareService(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Append.Blazor.WebShare/scripts.js").AsTask());
    }

    /// <inheritdoc/>
    public ValueTask ShareAsync(string title, string text, string url)
    {
        ShareData data = new(title, text, url);
        return ShareAsync(data);
    }

    /// <inheritdoc/>
    public async ValueTask ShareAsync(ShareData data)
    {
        var module = await moduleTask.Value;
        ShareResult result = await module.InvokeAsync<ShareResult>("share", data);

        if (!result.IsSuccess)
        {
            throw result switch
            {
                ShareResult r when r.ErrorName == "AbortError" => new WebShareAbortException(),
                ShareResult r when r.ErrorName == "NotAllowedError" => new WebShareNotAllowedException(),
                ShareResult r when r.ErrorName == "TypeError" => new WebShareTypeException(),
                ShareResult r when r.ErrorName == "DataError" => new WebShareDataException(),
                ShareResult r => new WebShareException(r.ErrorMessage!)
            };
        }
    }

    /// <inheritdoc/>
    public async ValueTask<bool> IsSupportedAsync()
    {
        var module = await moduleTask.Value;
        var isSupported = await module.InvokeAsync<bool>("isSupported");
        return isSupported;
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
