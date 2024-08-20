using AdminPanel.API.Models;

namespace AdminPanel.API.Repositories
{
    public interface IConfigurationRepository
    {
        Task<IEnumerable<Configuration>> GetAllConfigurationsAsync();
        Task<Configuration> GetConfigurationAsync(string buildingType);
        Task AddConfigurationAsync(Configuration configuration);
        Task UpdateConfigurationAsync(Configuration configuration);
        Task DeleteConfigurationAsync(string buildingType);
    }
}
