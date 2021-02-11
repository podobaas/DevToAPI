<p align="center">
<img src="https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/160/google/274/man-technologist_1f468-200d-1f4bb.png">
</p>
<h2 align="center">
  DevToAPI - Forem/DEV API Client Library for .NET
</h2>
<h4 align="center">
  Client library targeting .NET Framework 4.5.2+ and .NET Standard 2+
</h4>
<p align="center">
<img alt="GitHub Workflow Status" src="https://img.shields.io/github/workflow/status/podobaas/DevToAPI/DevToAPI%20CI?label=DevToAPI%20CI&style=flat-square">
<img alt="Nuget" src="https://img.shields.io/nuget/v/DevToAPI.svg?style=flat-square&label=nuget">
 <img alt="GitHub" src="https://img.shields.io/github/license/podobaas/DevToAPI?style=flat-square">
</p>

## Implemented endpoints

| Route  | Methods |
| ------------- | ------------- |
| [Articles](https://docs.dev.to/api/#tag/articles)  | All methods |
| [Comments](https://docs.dev.to/api/#tag/comments)  | All methods  |
| [Follows](https://docs.dev.to/api/#tag/follows)  | All methods |
| [Followers](https://docs.dev.to/api/#tag/followers)  | All methods  |
| [Listings](https://docs.dev.to/api/#tag/listings)  | All methods  |
| [Organizations](https://docs.dev.to/api/#tag/organizations)  | All methods  |
| [Podcast episodes](https://docs.dev.to/api/#tag/podcast-episodes)  | All methods  |
| [Reading list](https://docs.dev.to/api/#tag/readinglist)  | All methods  |
| [Tags](https://docs.dev.to/api/#tag/tags)  | All methods  |
| [Users](https://docs.dev.to/api/#tag/users)  | All methods |
| [Videos](https://docs.dev.to/api/#tag/videos)  | All methods  |
| [Webhooks](https://docs.dev.to/api/#tag/webhooks)  | All methods  |
| [Profile images](https://docs.dev.to/api/#tag/profile-images)  | All methods  |
| [Admin configuration](https://docs.dev.to/api/#tag/admin-configuration)  |  Not implemented  |

## Install

DevToAPI is available for install from [NuGet](https://www.nuget.org/packages/DevToAPI/)

```
dotnet add package DevToAPI
```

## Usage examples

### Create new article
```csharp
var client = new DevToClient("api-key");
await client.Articles.CreateAsync(new CreateArticle()
{
    Title = "My post",
    BodyMarkdown = "...",
    Tags = new List<string>()
    {
        "csharp",
        "opensource"
    },
    Published = true
});
```

### Specific page
```csharp
var client = new DevToClient("api-key");
var pagination = await client.Articles.GetAllMyAsync(option =>
{
    option.Page = 5;
    option.PageSize = 10;
});
```

### Pagination
```csharp
var client = new DevToClient("api-key");
var pagination = await client.Articles.GetAllMyAsync();

while (pagination.CanMoveNext)
{
    var myArticles = pagination.Items;

    //do stuff

    await pagination.NextPageAsync();
}
```
## Supported Platforms
* .NET 4.5.2 or greater
* .NET Standard 2.0 or greater

## Documentation

Check out [DEV API documentation](https://docs.dev.to/api/)

## References
+ [LICENSE](LICENSE)
+ [CONTRIBUTING](CONTRIBUTING.md)
+ [CHANGELOG](CHANGELOG.MD)
