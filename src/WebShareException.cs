using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Append.Blazor.WebShare;

public class WebShareException : Exception
{
    public WebShareException(string message): base(message) { }
}

/// <summary>
/// The user canceled the share operation or there are no share targets available.
/// </summary>
public class WebShareAbortException : WebShareException
{
    public WebShareAbortException() : base("User aborted the share request.") { }
}

/// <summary>
/// A web-share Permissions Policy has been used to block the use of this feature, the window does not have transient activation, or a file share is being blocked due to security considerations.
/// </summary>
public class WebShareNotAllowedException : WebShareException
{
    public WebShareNotAllowedException() : base("Sharing is not allowed in this device.") { }
}

/// <summary>
/// The specified share data cannot be validated. Possible reasons include:
/// The data parameter was omitted completely or only contains properties with unknown values.Note that any properties that are not recognized by the user agent are ignored.
/// A URL is badly formatted.
/// Files are specified but the implementation does not support file sharing.
/// Sharing the specified data would be considered a "hostile share" by the user-agent.
/// </summary>
public class WebShareTypeException : WebShareException
{
    public WebShareTypeException() : base("The specified share data is not valid.") { }
}

public class WebShareDataException : WebShareException
{
    public WebShareDataException() : base("There was a problem starting the share target or transmitting the data.\n\n") { }
}

