<p align="center">
<img src="https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/160/google/274/man-technologist_1f468-200d-1f4bb.png">
</p>
<h2 align="center">
  DevToAPI - Forem/DEV API Client Library for .NET
</h2>
<p align="center">
</p>

<h4 align="center">Client library targeting .NET Framework 4.5.2+ and .NET Standard 2+</h1>

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

DevToAPI is available for install from [NuGet]()

```
dotnet add package DevToAPI
```

## Usage examples

### Console
```csharp
var client = new DevToClient("api-key");
var me = await client.Users.GetMeAsync();
```

### ASP.NET Core
```csharp
collection.AddSingleton<IDevToClient>(x => new DevToClient("api-key")));
```

### Specific page
```csharp
var pagination = await client.ReadingLists.GetAsync(option => 
{
    Page = 5,
    PageSize = 10
});
```

### Pagination
```csharp
var pagination = await client.ReadingLists.GetAsync();

while (pagination.CanMoveNext)
{
   var lists = pagination.Items;
   
   // do stuff...
      
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