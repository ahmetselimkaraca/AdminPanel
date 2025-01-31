﻿using Amazon.DynamoDBv2.DataModel;

namespace AdminPanel.API.Models
{
    [DynamoDBTable("Configurations")]
    public class Configuration
    {
        [DynamoDBHashKey]
        public string BuildingType { get; set; }
        public int BuildingCost { get; set; }
        public int ConstructionTime { get; set; }
    }
}