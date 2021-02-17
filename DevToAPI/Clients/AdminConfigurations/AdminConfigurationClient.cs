using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.AdminConfigurations
{
    internal sealed class AdminConfigurationClient: ClientBase, IAdminConfigurationClient
    {
        protected override string Route => "admin";
        
        public AdminConfigurationClient(IApiConnection apiConnection) : base(apiConnection){}
        
        public async Task<TSiteConfig> GetAsync<TSiteConfig>() where TSiteConfig : class
        {
            return await ApiConnection.ExecuteGetAsync<TSiteConfig>($"{Route}/config").ConfigureAwait(false);
        }

        public async Task UpdateAsync<TSiteConfig>(TSiteConfig siteConfig) where TSiteConfig : class
        {
            ThrowHelper.ThrowIfNull(siteConfig, nameof(siteConfig));
            
            await ApiConnection.ExecutePutAsync($"{Route}/config", siteConfig).ConfigureAwait(false);
        }
    }
}