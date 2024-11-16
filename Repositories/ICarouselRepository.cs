using Greeno.Models.Domain;

namespace Greeno.Repositories
{
    public interface ICarouselRepository
    {
        Task<IEnumerable<Carousel>> GetAllAsync();

        Task<Carousel?> GetByIdAsync(Guid id);

        Task<Carousel?> AddAsync (Carousel carousel);

        Task<Carousel?> UpdateAsync (Carousel carousel);

        Task<Carousel?> DeleteAsync (Guid id);
    }
}
