using Amazon.DynamoDBv2.DataModel;

namespace AdminPanel.API.Models
{
    [DynamoDBTable("BuildingTypes")]
    public class BuildingType
    {
        [DynamoDBHashKey]
        public string TypeName { get; set; }
    }
}
