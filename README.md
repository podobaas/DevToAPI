<p align="center">
<img src="https://d2fltix0v2e0sb.cloudfront.net/dev-ecosystem.png" height="150" width="150">
</p>

<h2 align="center">
DevToAPI - Forem/DEV API Client Library for .NET
<br/>
<br/>
<img alt=".NET Framework" src="https://img.shields.io/badge/.NET%20Framework-4.5.2%2B-green">
<img alt=".NET Standard" src="https://img.shields.io/badge/.NET%20Standard-2%2B-green">
<br/>
<img alt="GitHub Workflow Status" src="https://img.shields.io/github/workflow/status/podobaas/DevToAPI/DevToAPI%20CI?color=green&label=build&logo=Github">
<img alt="Codacy grade" src="https://img.shields.io/codacy/grade/737a41d4c0754f5aabf83e826f0e5310?color=green&logo=Codacy">
<img alt="Nuget version" src="https://img.shields.io/nuget/v/DevToAPI.svg?color=green&style=flat&label=nuget&logo=Nuget">
<img alt="Nuget" src="https://img.shields.io/nuget/dt/DevToAPI?color=green&logo=Nuget">
<img alt="GitHub" src="https://img.shields.io/github/license/podobaas/DevToAPI?color=green&style=flat">
</h2>
<br/>
<br/>

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
| [Admin configuration](https://docs.dev.to/api/#tag/admin-configuration)  |  All methods  |

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
+ [CHANGELOG](CHANGELOG.md)
