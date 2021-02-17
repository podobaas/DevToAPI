using System.Collections.Generic;
using System.Threading.Tasks;
using DevToAPI.Types;
using RestSharp;

namespace DevToAPI.Http
{
    public interface IApiConnection
    {
        Task<TResponse> ExecuteGetAsync<TResponse>(string endpoint);
        
        Task<IReadOnlyList<TResponse>> ExecuteGetCollectionAsync<TResponse>(string endpoint);
        
        Task<IPagination<TResponse>> ExecutePaginationGetAsync<TResponse>(string endpoint, object queryOption);
        
        Task<TResponse> ExecuteGetAsync<TResponse>(RestRequest restRequest);

        Task<TResponse> ExecutePostAsync<TRequest, TResponse>(string endpoint, TRequest request);
        
        Task<TResponse> ExecutePutAsync<TRequest, TResponse>(string endpoint, TRequest request);
        
        Task ExecutePutAsync<TRequest>(string endpoint, TRequest request);
        
        Task ExecuteDeleteAsync(string endpoint);
    }
}