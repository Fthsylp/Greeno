using Greeno.Models.Domain;

namespace Greeno.Repositories
{
    public interface IGalleryRepository
    {
        Task<IEnumerable<Gallery>> GetAllAsync();

        Task<Gallery?> GetByIdAsync(Guid id);

        Task<Gallery?> AddAsync(Gallery gallery);

        Task<Gallery?> UpdateAsync(Gallery gallery);

        Task<Gallery?> DeleteAsync(Guid id);
    }
}
