# Web Share
Implementation of the [Web Share  API](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/share) in C# for [Microsoft Blazor](https://github.com/aspnet/Blazor). The Web Share API allows a site to share text, links and other content to user-selected share targets, utilizing the sharing mechanisms of the underlying operating system. 

[![Package Version](https://img.shields.io/nuget/v/Append.Blazor.WebShare.svg)](https://www.nuget.org/packages/Append.Blazor.WebShare)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Append.Blazor.WebShare.svg)](https://www.nuget.org/packages/Append.Blazor.WebShare)
[![License](https://img.shields.io/github/license/Append-IT/Blazor.WebShare.svg)](https://github.com/Append-IT/Blazor.WebShare/blob/main/LICENSE)

## Preview


https://user-images.githubusercontent.com/10981553/213947131-b33c38e6-2481-4e67-b4af-631c8acc1013.mov



## Installation

```
Install-Package Append.Blazor.WebShare
```

## Demo
There is a sample application in /docs folder which is also hosted as [documentation](https://wonderful-smoke-084433603.2.azurestaticapps.net). 

## Usage

### Add `IWebShareService` via DI in `Program.cs`
> Scoped by default.
```csharp
builder.Services.AddWebShare();
```

### Inject into component/pages
```csharp
@using Append.Blazor.WebShare
@inject IWebShareService WebShareService
```

or

### Inject on a `BlazorComponent` class:

```c#
[Inject] public IWebShareService WebShareService { get; set; } = default!;
```

 ### Browser Support
```csharp
bool IsSupported = await WebShareService.IsSupportedAsync()
```

### Create a share
#### Using a Function (basic)
```csharp
await WebShareService.ShareAsync("Title", "Text", "https://www.google.com");
```

# Contributions and feedback

Please feel free to use the component, open issues, fix bugs or provide feedback.

# Contributors

This project is created and maintained by:

- [Benjamin Vertonghen](https://github.com/vertonghenb)
