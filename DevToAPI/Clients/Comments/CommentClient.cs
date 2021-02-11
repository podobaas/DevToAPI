using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Responses;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Comments
{
    internal sealed class CommentClient: ClientBase, ICommentClient
    {
        protected override string Route => "comments";
        
        public CommentClient(IApiConnection apiConnection) : base(apiConnection){}

        public async Task<Comment> GetByIdAsync(string commentId)
        {
            ThrowHelper.ThrowIfNullOrEmpty(commentId, nameof(commentId));

            return await ApiConnection.ExecuteGetAsync<Comment>($"{Route}/{commentId}").ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<Comment>> GetByArticleIdAsync(int articleId)
        {
            ThrowHelper.ThrowIfLessThanOne(articleId, nameof(articleId));

            return await ApiConnection.ExecuteGetCollectionAsync<Comment>($"{Route}?a_id={articleId}").ConfigureAwait(false);
        }
        
        public async Task<IReadOnlyList<Comment>> GetByPodcastIdAsync(int podcastId)
        {
            ThrowHelper.ThrowIfLessThanOne(podcastId, nameof(podcastId));
            
            return await ApiConnection.ExecuteGetCollectionAsync<Comment>($"{Route}?p_id={podcastId}").ConfigureAwait(false);
        }
    }
}