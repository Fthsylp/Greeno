using Greeno.Data;
using Greeno.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Greeno.Repositories
{
    public class PlantContainerRepository : IPlantContainerRepository
    {
        private readonly GreenoDbContext greenoDbContext;

        public PlantContainerRepository(GreenoDbContext greenoDbContext)
        {
            this.greenoDbContext = greenoDbContext;
        }

        public async Task<PlantContainer?> AddAsync(PlantContainer plantContainer)
        {
            await greenoDbContext.AddAsync(plantContainer);
            await greenoDbContext.SaveChangesAsync();
            return plantContainer;
        }

        public async Task<PlantContainer?> DeleteAsync(Guid id)
        {
            var existingPlant = await greenoDbContext.PlantContainers.FindAsync(id);
            if (existingPlant != null)
            {
                greenoDbContext.PlantContainers.Remove(existingPlant);
                await greenoDbContext.SaveChangesAsync();
                return existingPlant;
            }
            return null;
        }

        public async Task<IEnumerable<PlantContainer>> GetAllAsync()
        {
            return await greenoDbContext.PlantContainers.ToListAsync();
        }

        public async Task<PlantContainer?> GetByIdAsync(Guid id)
        {
            return await greenoDbContext.PlantContainers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PlantContainer?> UpdateAsync(PlantContainer plantContainer)
        {
            var existingPlant = await greenoDbContext.PlantContainers.FirstOrDefaultAsync(x => x.Id == plantContainer.Id);

            if (existingPlant != null)
            {
                existingPlant.Id = plantContainer.Id;
                existingPlant.Title = plantContainer.Title;
                existingPlant.Description = plantContainer.Description;
                existingPlant.Image = plantContainer.Image;

                await greenoDbContext.SaveChangesAsync();
                return existingPlant;
            }

            return null;
        }
    }
}
