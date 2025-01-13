using AutoMapper;
using HeribertoAPI.Models.Domain;
using HeribertoAPI.Models.DTO;
using HeribertoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeribertoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var regions = await regionRepository.GetAllAsync();
            return Ok(mapper.Map<List<RegionDto>>(regions));
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await this.regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(region));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or convert DTO to Domain Model
            var newRegion= await this.regionRepository.Create(mapper.Map<Region>(addRegionRequestDto));
            var regionDto = mapper.Map<RegionDto>(newRegion);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id}, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var existingRegion = await this.regionRepository.Update(id, updateRegionRequestDto);
            if (existingRegion == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(existingRegion));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var existingRegion = await regionRepository.Remove(id);
            if (existingRegion == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(existingRegion));

        }


    }
}
