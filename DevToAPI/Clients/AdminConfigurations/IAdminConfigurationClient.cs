using System.Threading.Tasks;

namespace DevToAPI.Clients.AdminConfigurations
{
    /// <summary>
    /// Site-wide configuration set by admins (requires super admin authorization)
    /// </summary>
    public interface IAdminConfigurationClient
    {
        /// <summary>
        /// This method returns the "site config" as set by admin.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getConfig">getConfig</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<TSiteConfig> GetAsync<TSiteConfig>() where TSiteConfig : class;

        /// <summary>
        /// This method allows admins to declare values or update values for "site config".
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/upsertConfig">upsertConfig</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task UpdateAsync<TSiteConfig> (TSiteConfig siteConfig) where TSiteConfig : class;
    }
}