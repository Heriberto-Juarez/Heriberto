using HeribertoAPI.Models.Domain;
using HeribertoAPI.Models.DTO;

namespace HeribertoAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> Create(Region region);

        Task<Region?> Update(Guid id, UpdateRegionRequestDto region);

        Task<Region?> Remove(Guid id);

    }
}
