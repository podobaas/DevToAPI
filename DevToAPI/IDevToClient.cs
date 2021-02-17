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

namespace DevToAPI
{
    /// <summary>
    /// API client
    /// </summary>
    public interface IDevToClient
    {
        /// <summary>
        /// Site-wide configuration set by admins (requires super admin authorization)
        /// </summary>
        IAdminConfigurationClient AdminConfigurations { get; }
        
        /// <summary>
        /// Articles are all the posts users create on DEV
        /// </summary>
        IArticleClient Articles { get; }
        
        /// <summary>
        /// Users can leave comments to articles and podcasts episodes
        /// </summary>
        ICommentClient Comments { get; }
        
        /// <summary>
        /// Resources are user can follow
        /// </summary>
        IFollowerClient Followers { get; }
        
        /// <summary>
        /// Users can follow other users on the website
        /// </summary>
        IFollowClient Follows { get; }
        
        /// <summary>
        /// Listings are classified ads
        /// </summary>
        IListingClient Listings { get; }
        
        /// <summary>
        /// Users can create and join organizations
        /// </summary>
        IOrganizationClient Organizations { get; }
        
        /// <summary>
        /// Podcast episodes
        /// </summary>
        IPodcastEpisodeClient PodcastEpisodes { get; }

        /// <summary>
        /// User's reading list
        /// </summary>
        IReadingListClient ReadingLists { get; }
        
        /// <summary>
        /// Tags for articles
        /// </summary>
        ITagClient Tags { get; }
        
        /// <summary>
        /// Users own resources that require authentication
        /// </summary>
        IUserClient Users { get; }
        
        /// <summary>
        /// Video articles
        /// </summary>
        IVideoClient Videos { get; }
        
        /// <summary>
        /// Webhooks are HTTP endpoints registered to receive events
        /// </summary>
        IWebhookClient Webhooks { get; }
        
        /// <summary>
        /// User or organization profile images
        /// </summary>
        IProfileImageClient ProfileImages { get; }
    }
}