using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevToAPI.Http;
using RestSharp;

namespace DevToAPI.Types
{
    internal class Pagination<TResponse>: IPagination<TResponse>
    {
        private readonly IApiConnection _apiConnection;
        private readonly RestRequest _restRequest;
        
        public int Page { get; private set; }
        
        public int PageSize { get; }
        
        public bool CanMoveNext { get; private set; }
        
        public IList<TResponse> Items { get; private set; }

        public Pagination(IApiConnection apiConnection, RestRequest restRequest, IList<TResponse> items)
        {
            _apiConnection = apiConnection;
            _restRequest = restRequest;

            Items = items;
            Page = Convert.ToInt32(restRequest.Parameters.Find(x => x.Name == "page").Value);
            PageSize = Convert.ToInt32(restRequest.Parameters.Find(x => x.Name == "per_page").Value);
        }
        
        public async Task NextPageAsync()
        {
            Page += 1;
            _restRequest.Parameters.Find(x => x.Name == "page").Value = Page;
            var response = await _apiConnection.ExecuteGetAsync<IList<TResponse>>(_restRequest).ConfigureAwait(false);
            Items = response;

            if (response.Any() && response.Count() == PageSize)
            {
                CanMoveNext = true;
            }
            else
            {
                CanMoveNext = false;
            }
        }
    }
}