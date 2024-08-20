using AdminPanel.API.Models;

namespace AdminPanel.API.Repositories
{
    public interface IBuildingTypeRepository
    {
        Task<IEnumerable<string>> GetAllAsync();
        Task<BuildingType> GetAsync(string buildingType);
        Task AddAsync(BuildingType buildingType);
        Task DeleteAsync(string buildingType);
        Task<bool> IsValidAsync(string buildingType);
    }
}