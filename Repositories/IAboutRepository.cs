using Greeno.Models.Domain;

namespace Greeno.Repositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAllAsync();

        Task<About?> GetByIdAsync(Guid id);

        Task<About?> AddAsync(About about);

        Task<About?> UpdateAsync(About about);

        Task<About?> DeleteAsync(Guid id);
    }
}
