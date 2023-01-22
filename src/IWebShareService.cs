namespace Append.Blazor.WebShare;

public interface IWebShareService
{
    /// <summary>
    /// Invokes the native sharing mechanism of the device to share data such as text, URLs.
    /// The available share targets depend on the device, but might include the clipboard, contacts and email applications, websites, Bluetooth, etc.
    /// </summary>
    /// <param name="title">A string representing a title to be shared. May be ignored by the target.</param>
    /// <param name="text">A string representing text to be shared.</param>
    /// <param name="url">A string representing a URL to be shared.</param>
    ValueTask ShareAsync(string title, string text, string url);
    /// <summary>
    /// Invokes the native sharing mechanism of the device to share data such as text, URLs.
    /// The available share targets depend on the device, but might include the clipboard, contacts and email applications, websites, Bluetooth, etc.
    /// </summary>
    /// <param name="data">An object containing data to share.</param>
    /// 
    ValueTask ShareAsync(ShareData data);
    /// <summary>
    /// Checks if the Web Share API is support on the platform.
    /// </summary>
    /// <returns>true if supported, false if not.</returns>
    ValueTask<bool> IsSupportedAsync();
}