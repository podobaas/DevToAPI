using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.Articles
{
    /// <summary>
    /// Articles are all the posts users create on DEV
    /// </summary>
    public interface IArticleClient
    {
        /// <summary>
        /// Retrieve a list of published articles on behalf of an authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUserPublishedArticles">getUserPublishedArticles</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<MyArticle>> GetMyPublishedAsync();
        
        /// <summary>
        /// Retrieve a list of published articles on behalf of an authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUserPublishedArticles">getUserPublishedArticles</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<MyArticle>> GetMyPublishedAsync(Action<PageQueryOption> action);

        /// <summary>
        /// Retrieve a list of published articles on behalf of an authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUserUnpublishedArticles">getUserUnpublishedArticles</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<MyArticle>> GetMyUnpublishedAsync();
        
        /// <summary>
        /// Retrieve a list of published articles on behalf of an authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUserUnpublishedArticles">getUserUnpublishedArticles</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<MyArticle>> GetMyUnpublishedAsync(Action<PageQueryOption> action);

        /// <summary>
        /// Retrieve a list of all articles on behalf of an authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUserAllArticles">getUserAllArticles</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<MyArticle>> GetAllMyAsync();
        
        /// <summary>
        /// Retrieve a list of all articles on behalf of an authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUserAllArticles">getUserAllArticles</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<MyArticle>> GetAllMyAsync(Action<PageQueryOption> action);

        /// <summary>
        /// Retrieve a list of articles.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getArticles">getArticles</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<Article>> GetAsync();
        
        /// <summary>
        /// Retrieve a list of articles.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getArticles">getArticles</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<Article>> GetAsync(Action<ArticleQueryOption> action);

        /// <summary>
        /// Retrieve a single published article given it's id.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getArticleById">getArticleById</a> for more information
        /// </remarks>
        /// <param name="articleId">Id of the article</param>
        /// <returns></returns>
        Task<Article> GetByIdAsync(int articleId);

        /// <summary>
        /// Retrieve a single published article given it's path.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getArticleByPath">getArticleByPath</a> for more information
        /// </remarks>
        /// <param name="username">User or organization username</param>
        /// <param name="slug">Slug of the article</param>
        /// <returns></returns>
        Task<Article> GetByPathAsync(string username, string slug);

        /// <summary>
        /// Create a new article.
        /// There is a limit of 10 requests per 30 seconds.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/createArticle">createArticle</a> for more information
        /// </remarks>
        /// <param name="article">New article</param>
        /// <returns></returns>
        Task<Article> CreateAsync(CreateArticle article);

        /// <summary>
        /// Update an existing article.
        /// There is a limit of 30 requests per 30 seconds.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/updateArticle">updateArticle</a> for more information
        /// </remarks>
        /// <param name="articleId">Id of the article</param>
        /// <param name="article">Article</param>
        /// <returns></returns>
        Task<Article> UpdateAsync(int articleId, UpdateArticle article);
    }
}