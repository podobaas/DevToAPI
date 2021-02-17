using DevToAPI.Clients.AdminConfigurations;
using DevToAPI.Clients.Articles;
using DevToAPI.Clients.Comments;
using DevToAPI.Clients.Followers;
using DevToAPI.Clients.Follows;
using DevToAPI.Clients.Listings;
using DevToAPI.Clients.Organizations;
using DevToAPI.Clients.PodcastEpisodes;
using DevToAPI.Clients.ProfileImages;
using DevToAPI.Clients.ReadingLists;
using DevToAPI.Clients.Tags;
using DevToAPI.Clients.Users;
using DevToAPI.Clients.Videos;
using DevToAPI.Clients.Webhooks;
using DevToAPI.Http;
using RestSharp;

namespace DevToAPI
{
    /// <summary>
    /// API client
    /// </summary>
    public sealed class DevToClient : IDevToClient
    {
        private const string ApiUrl = "https://dev.to/api/";
        
        /// <summary>
        /// Site-wide configuration set by admins (requires super admin authorization)
        /// </summary>
        public IAdminConfigurationClient AdminConfigurations { get;}
        
        /// <summary>
        /// Articles are all the posts users create on DEV
        /// </summary>
        public IArticleClient Articles { get;}
        
        /// <summary>
        /// Users can leave comments to articles and podcasts episodes
        /// </summary>
        public ICommentClient Comments { get; }
        
        /// <summary>
        /// Resources are user can follow
        /// </summary>
        public IFollowerClient Followers { get; }
        
        /// <summary>
        /// Users can follow other users on the website
        /// </summary>
        public IFollowClient Follows { get; }
        
        /// <summary>
        /// Listings are classified ads
        /// </summary>
        public IListingClient Listings { get; }
        
        /// <summary>
        /// Users can create and join organizations
        /// </summary>
        public IOrganizationClient Organizations { get; }
        
        /// <summary>
        /// Podcast episodes
        /// </summary>
        public IPodcastEpisodeClient PodcastEpisodes { get; }

        /// <summary>
        /// User's reading list
        /// </summary>
        public IReadingListClient ReadingLists { get; }
        
        /// <summary>
        /// Tags for articles
        /// </summary>
        public ITagClient Tags { get; }
        
        /// <summary>
        /// Users own resources that require authentication
        /// </summary>
        public IUserClient Users { get; }
        
        /// <summary>
        /// Video articles
        /// </summary>
        public IVideoClient Videos { get; }
        
        /// <summary>
        /// Webhooks are HTTP endpoints registered to receive events
        /// </summary>
        public IWebhookClient Webhooks { get; }
        
        /// <summary>
        /// User or organization profile images
        /// </summary>
        public IProfileImageClient ProfileImages { get; }
        
        /// <summary>
        /// API client
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#section/Authentication/api_key">Authentication</a> for more information
        /// </remarks>
        /// <param name="token">API key</param>
        public DevToClient(string token)
        {
            var restClient = new RestClient(ApiUrl);
            restClient.AddDefaultHeader("api-key", token);
            restClient.AddDefaultHeader("User-Agent", "DevToAPI-client-dotnet");
            var apiConnection = new ApiConnection(restClient);

            AdminConfigurations = new AdminConfigurationClient(apiConnection);
            Articles = new ArticleClient(apiConnection);
            Comments = new CommentClient(apiConnection);
            Followers = new FollowerClient(apiConnection);
            Follows = new FollowClient(apiConnection);
            Listings = new ListingClient(apiConnection);
            Organizations = new OrganizationClient(apiConnection);
            PodcastEpisodes = new PodcastEpisodeClient(apiConnection);
            ReadingLists = new ReadingListClient(apiConnection);
            Tags = new TagClient(apiConnection);
            Users = new UserClient(apiConnection);
            Videos = new VideoClient(apiConnection);
            Webhooks = new WebhookClient(apiConnection);
            ProfileImages = new ProfileImageClient(apiConnection);
        }

        /// <summary>
        /// API client
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#section/Authentication/api_key">Authentication</a> for more information
        /// </remarks>
        /// <param name="apiUrl">API connection url</param>
        /// <param name="token">API key</param>
        public DevToClient(string apiUrl, string token)
        {
            var restClient = new RestClient(apiUrl);
            restClient.AddDefaultHeader("api-key", token);
            restClient.AddDefaultHeader("User-Agent", "DevToAPI-client-dotnet");
            var apiConnection = new ApiConnection(restClient);
            
            AdminConfigurations = new AdminConfigurationClient(apiConnection);
            Articles = new ArticleClient(apiConnection);
            Comments = new CommentClient(apiConnection);
            Followers = new FollowerClient(apiConnection);
            Follows = new FollowClient(apiConnection);
            Listings = new ListingClient(apiConnection);
            Organizations = new OrganizationClient(apiConnection);
            PodcastEpisodes = new PodcastEpisodeClient(apiConnection);
            ReadingLists = new ReadingListClient(apiConnection);
            Tags = new TagClient(apiConnection);
            Users = new UserClient(apiConnection);
            Videos = new VideoClient(apiConnection);
            Webhooks = new WebhookClient(apiConnection);
            ProfileImages = new ProfileImageClient(apiConnection);
        }
    }
}