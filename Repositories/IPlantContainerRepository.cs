using Greeno.Models.Domain;

namespace Greeno.Repositories
{
    public interface IPlantContainerRepository
    {
        Task<IEnumerable<PlantContainer>> GetAllAsync();

        Task<PlantContainer?> GetByIdAsync(Guid id);

        Task<PlantContainer?> AddAsync(PlantContainer plantContainer);

        Task<PlantContainer?> UpdateAsync(PlantContainer plantContainer);

        Task<PlantContainer?> DeleteAsync(Guid id);
    }
}
