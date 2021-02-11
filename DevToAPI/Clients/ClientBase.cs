using DevToAPI.Http;

namespace DevToAPI.Clients
{
    internal abstract class ClientBase
    {
        protected abstract string Route { get; }
        
        protected IApiConnection ApiConnection { get; }
        
        protected ClientBase(IApiConnection apiConnection)
        {
            ApiConnection = apiConnection;
        }
    }
}