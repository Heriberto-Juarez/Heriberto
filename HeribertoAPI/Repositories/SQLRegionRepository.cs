using HeribertoAPI.Data;
using HeribertoAPI.Models.Domain;
using HeribertoAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HeribertoAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {

        private readonly HeribertoDbContext dbContext;

        public SQLRegionRepository(HeribertoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> Create(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> Update(Guid id, UpdateRegionRequestDto region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r=>r.Id == id);
            if (existingRegion == null)
            {
                return existingRegion;
            }

            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            existingRegion.Name = region.Name;

            dbContext.Regions.Update(existingRegion);

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> Remove(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null) {
                return null;
            }
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
    }
}
