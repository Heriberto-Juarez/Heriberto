using AutoMapper;
using HeribertoAPI.Models.Domain;
using HeribertoAPI.Models.DTO;
using HeribertoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeribertoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IwalkRepository repository;

        public WalksController(IMapper mapper, IwalkRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);
            var newWalk = await repository.CreateAsync(walkDomain);

            var dto = mapper.Map<WalkDto>(newWalk);
            return StatusCode(StatusCodes.Status201Created, dto);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var walksModels = await repository.ListAllAsync(filterOn, filterQuery);
            var walksDtos = mapper.Map<List<WalkDto>>(walksModels);
            return Ok(walksDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walk = await repository.GetByIdAsync(id);

            if (walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walk = await repository.UpdateAsync(id, mapper.Map<Walk>(updateWalkRequestDto));
            if (walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var walk = await repository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
