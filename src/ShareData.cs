using System.Collections.Generic;

namespace Append.Blazor.WebShare;

/// <summary>
/// An object containing data to share.
/// Properties that are unknown to the user agent are ignored; share data is only assessed on properties understood by the user agent.
/// All properties are optional but at least one known data property must be specified.
/// </summary>
public class ShareData
{
    /// <summary>
    /// A string representing a title to be shared. May be ignored by the target.
    /// </summary>
    public string? Title { get; init; }
    /// <summary>
    /// A string representing text to be shared.
    /// </summary>
    public string? Text { get; init; }
    /// <summary>
    /// A string representing URL to be shared.
    /// </summary>
    public string? Url { get; init; }

    public ShareData() { }
    public ShareData(string? title, string? text, string? url)
    {
        Title = title;
        Text = text;
        Url = url;
    }
}