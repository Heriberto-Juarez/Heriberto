using HeribertoAPI.Models.Domain;

namespace HeribertoAPI.Repositories
{
    public interface IwalkRepository
    {

        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> ListAllAsync(string? filterOn=null, string? filterQuery = null);

        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);


        Task<Walk?> DeleteAsync(Guid id);

    }
}
