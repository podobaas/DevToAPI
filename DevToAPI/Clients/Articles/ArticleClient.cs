using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Articles
{
    internal sealed class ArticleClient: ClientBase, IArticleClient
    {
        protected override string Route => "articles";
        
        public ArticleClient(IApiConnection apiConnection): base(apiConnection){}

        public async Task<IPagination<MyArticle>> GetMyPublishedAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);

            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<MyArticle>($"{Route}/me/published", queryOption).ConfigureAwait(false);
        }

        public async Task<IPagination<MyArticle>> GetMyUnpublishedAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);

            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<MyArticle>($"{Route}/me/unpublished", queryOption).ConfigureAwait(false);
        }

        public async Task<IPagination<MyArticle>> GetAllMyAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);

            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<MyArticle>($"{Route}/me/all", queryOption).ConfigureAwait(false);
        }
        
        public async Task<IPagination<Article>> GetAsync(Action<ArticleQueryOption> action = null)
        {
            var queryOption = new ArticleQueryOption();
            action?.Invoke(queryOption);

            ThrowHelper.ThrowIfLessThanOne(queryOption.Top, nameof(queryOption.Top));
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            
            return await ApiConnection.ExecutePaginationGetAsync<Article>(Route, queryOption).ConfigureAwait(false);
        }

        public async Task<Article> GetByIdAsync(int articleId)
        {
            ThrowHelper.ThrowIfLessThanOne(articleId, nameof(articleId));
            
            return await ApiConnection.ExecuteGetAsync<Article>($"{Route}/{articleId}").ConfigureAwait(false);
        }

        public async Task<Article> GetByPathAsync(string username, string slug)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));
            ThrowHelper.ThrowIfNullOrEmpty(slug, nameof(slug));

            return await ApiConnection.ExecuteGetAsync<Article>($"{Route}/{username}/{slug}").ConfigureAwait(false);
        }

        public async Task<Article> CreateAsync(CreateArticle article)
        {
            ThrowHelper.ThrowIfNull(article, nameof(article));
            
            var request = new {article};
            return await ApiConnection.ExecutePostAsync<object,Article>(Route, request).ConfigureAwait(false);
        }

        public async Task<Article> UpdateAsync(int articleId, UpdateArticle article)
        {
            ThrowHelper.ThrowIfLessThanOne(articleId, nameof(articleId));
            ThrowHelper.ThrowIfNull(article, nameof(article));
            
            var request = new {article};
            return await ApiConnection.ExecutePutAsync<object,Article>($"{Route}/{articleId}", request).ConfigureAwait(false);
        }
    }
}