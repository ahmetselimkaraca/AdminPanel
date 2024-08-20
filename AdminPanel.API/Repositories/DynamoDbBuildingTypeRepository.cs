using Amazon.DynamoDBv2.DataModel;
using AdminPanel.API.Models;

namespace AdminPanel.API.Repositories
{
    public class DynamoDbBuildingTypeRepository : IBuildingTypeRepository
    {
        private readonly IDynamoDBContext _context;

        public DynamoDbBuildingTypeRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            var buildingTypes = await _context.ScanAsync<BuildingType>(conditions).GetRemainingAsync();
            return buildingTypes.Select(bt => bt.TypeName);
        }

        public async Task<BuildingType> GetAsync(string buildingType)
        {
            return await _context.LoadAsync<BuildingType>(buildingType);
        }

        public async Task AddAsync(BuildingType buildingType)
        {
            await _context.SaveAsync(buildingType);
        }

        public async Task DeleteAsync(string buildingType)
        {
            await _context.DeleteAsync<BuildingType>(buildingType);
        }

        public async Task<bool> IsValidAsync(string buildingType)
        {
            var buildingTypeEntity = await _context.LoadAsync<BuildingType>(buildingType);
            return buildingTypeEntity != null;
        }
    }
}