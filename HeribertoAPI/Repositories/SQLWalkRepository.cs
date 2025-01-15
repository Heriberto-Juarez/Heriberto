using HeribertoAPI.Data;
using HeribertoAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HeribertoAPI.Repositories
{
    public class SQLWalkRepository : IwalkRepository
    {
        private readonly HeribertoDbContext dbContext;

        public SQLWalkRepository(HeribertoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> ListAllAsync(string? filterOn, string? filterQuery)
        {
            var walks = dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            return await walks.ToListAsync();

            //return await dbContext.Walks.Include(x=> x.Difficulty).Include(x=> x.Region).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include(x=>x.Difficulty).Include(x=>x.Region).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await this.dbContext.Walks.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.LengthInKm = walk.LengthInKm;

            dbContext.Walks.Update(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await this.dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

    }
}
