using AutoMapper;
using AdminPanel.API.DTO;
using AdminPanel.API.DTO.BuildingTypeDTO;
using AdminPanel.API.DTO.ConfigurationDTO;
using AdminPanel.API.Models;

namespace AdminPanel.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Configuration, ConfigurationDto>().ReverseMap();
            CreateMap<Configuration, CreateConfigurationDto>().ReverseMap();
            CreateMap<Configuration, UpdateConfigurationDto>().ReverseMap();

            CreateMap<BuildingType, BuildingTypeDto>().ReverseMap();
            CreateMap<BuildingType, CreateBuildingTypeDto>().ReverseMap();
        }
    }
}