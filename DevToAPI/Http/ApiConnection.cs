using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevToAPI.Exceptions;
using DevToAPI.Helpers;
using DevToAPI.Models.Responses;
using DevToAPI.Types;
using DevToAPI.Types.Attributes;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;

namespace DevToAPI.Http
{
    internal sealed class ApiConnection: IApiConnection
    {
        private readonly IRestClient _restClient;
        
        public ApiConnection(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<TResponse> ExecuteGetAsync<TResponse>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET, DataFormat.Json);
            var response = await _restClient.ExecuteGetAsync<TResponse>(request).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }
        
        public async Task<IReadOnlyList<TResponse>> ExecuteGetCollectionAsync<TResponse>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET, DataFormat.Json);
            var response = await _restClient.ExecuteGetAsync<List<TResponse>>(request).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return new ReadOnlyCollection<TResponse>(response.Data);
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }
        
        public async Task<IPagination<TResponse>> ExecutePaginationGetAsync<TResponse>(string endpoint, object queryOption)
        {
            ThrowHelper.ThrowIfNull(queryOption, nameof(queryOption));
            
            var request = new RestRequest(endpoint, Method.GET, DataFormat.Json);
            SetQueryParams(queryOption, request);

            var response = await _restClient.ExecuteGetAsync<List<TResponse>>(request).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return new Pagination<TResponse>(this, request, response.Data);
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }
        
        public async Task<TResponse> ExecuteGetAsync<TResponse>(RestRequest restRequest)
        {
            if (restRequest == null)
            {
                throw new ArgumentNullException(nameof(restRequest));
            }

            var response = await _restClient.ExecuteGetAsync<TResponse>(restRequest).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }

        public async Task<TResponse> ExecutePostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            _restClient.AddDefaultHeader("Content-Type", "application/json");
            var restRequest = new RestRequest(endpoint, Method.POST, DataFormat.Json);
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            
            var response = await _restClient.ExecutePostAsync<TResponse>(restRequest).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }
        
        public async Task<TResponse> ExecutePutAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            _restClient.AddDefaultHeader("Content-Type", "application/json");
            var restRequest = new RestRequest(endpoint, Method.PUT, DataFormat.Json);
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            
            var response = await _restClient.ExecuteAsync<TResponse>(restRequest).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }

        public async Task ExecuteDeleteAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.DELETE);

            var response = await _restClient.ExecuteAsync(request).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                return;
            }

            var error = new JsonDeserializer().Deserialize<Error>(response);
            throw new DevToApiException(error);
        }

        private static void SetQueryParams(object queryOption, IRestRequest restRequest)
        {
            var props = queryOption.GetType().GetProperties();
            foreach (var prop in props)
            {
                var attributes = prop.GetCustomAttributes<QueryParamAttribute>(true);
                foreach (var attribute in attributes)
                {
                    var val = prop.GetValue(queryOption, null);
                    
                    if (val == null)
                    {
                        continue;
                    }

                    if (val.GetType().IsEnum)
                    {
                        var enumType = val.GetType();
                        var name = Enum.GetName(enumType, val);
                        var enumAttrib = enumType.GetField(name)
                                                 .GetCustomAttributes(false)
                                                 .OfType<QueryParamAttribute>()
                                                 .SingleOrDefault();

                        restRequest.AddQueryParameter(attribute.Name, enumAttrib?.Name ?? string.Empty);
                    }
                    else
                    {
                        restRequest.AddQueryParameter(attribute.Name, val.ToString());
                    }
                }
            }
        }
    }
}