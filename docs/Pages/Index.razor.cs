using Microsoft.AspNetCore.Components;

namespace Append.Blazor.WebShare.Documentation.Pages;
public partial class Index
{
    [Inject] public IWebShareService WebShareService { get; set; } = default!;
    private string? result;
    private async Task ShareAsync()
    {
        try
        {
            await WebShareService.ShareAsync("Your Title", "Your Custom Text", "www.google.com");
        }
        catch (WebShareAbortException ex)
        {
            // User aborted. (iOS)
            result = ex.Message;
        }
        catch (WebShareException ex)
        {
            result = ex.Message;
        }
    }
}

