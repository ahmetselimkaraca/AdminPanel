using Microsoft.AspNetCore.Mvc;
using AdminPanel.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using AdminPanel.API.DTO.BuildingTypeDTO;
using AdminPanel.API.Models;

namespace AdminPanel.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuildingTypesController : ControllerBase
    {
        private readonly IBuildingTypeRepository _buildingTypeRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;

        public BuildingTypesController(IBuildingTypeRepository buildingTypeRepository, IConfigurationRepository configurationRepository, IMapper mapper
        )
        {
            _buildingTypeRepository = buildingTypeRepository;
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAll()
        {
            return await _buildingTypeRepository.GetAllAsync();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBuildingTypeDto createBuildingTypeDto)
        {
            var buildingType = _mapper.Map<BuildingType>(createBuildingTypeDto);
            await _buildingTypeRepository.AddAsync(buildingType);

            var buildingTypeDto = _mapper.Map<BuildingTypeDto>(buildingType);
            return Ok(buildingTypeDto);
        }

        [Authorize]
        [HttpDelete("{buildingType}")]
        public async Task<IActionResult> Delete(string buildingType)
        {
            var existingBuildingType = await _buildingTypeRepository.GetAsync(buildingType);
            if (existingBuildingType == null)
            {
                return NotFound();
            }

            // delete the configuration that has the same building type
            var configuration = await _configurationRepository.GetConfigurationAsync(buildingType);

            if (configuration != null)
            {
                await _configurationRepository.DeleteConfigurationAsync(buildingType);
            }

            await _buildingTypeRepository.DeleteAsync(buildingType);

            return Ok();
        }


    }
}