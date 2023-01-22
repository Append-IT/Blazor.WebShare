using System;
namespace Append.Blazor.WebShare;

internal class ShareResult
{
    public bool IsSuccess { get; set; }
    public string? ErrorName { get; set; }
    public string? ErrorMessage { get; set; }
}

