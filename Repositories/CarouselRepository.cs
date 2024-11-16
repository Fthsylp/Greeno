using Greeno.Data;
using Greeno.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Greeno.Repositories
{
    public class CarouselRepository : ICarouselRepository
    {
        private readonly GreenoDbContext greenoDbContext;

        public CarouselRepository(GreenoDbContext greenoDbContext)
        {
            this.greenoDbContext = greenoDbContext;
        }

        public async Task<Carousel?> AddAsync(Carousel carousel)
        {
            await greenoDbContext.AddAsync(carousel);
            await greenoDbContext.SaveChangesAsync();
            return carousel;
        }

        public async Task<Carousel?> DeleteAsync(Guid id)
        {
            var existingCarousel = await greenoDbContext.Carousels.FindAsync(id);
            if (existingCarousel != null)
            {
                greenoDbContext.Carousels.Remove(existingCarousel);
                await greenoDbContext.SaveChangesAsync();
                return existingCarousel;
            }
            return null;
        }

        public async Task<IEnumerable<Carousel>> GetAllAsync()
        {
            return await greenoDbContext.Carousels.ToListAsync();
        }

        public async Task<Carousel?> GetByIdAsync(Guid id)
        {
            return await greenoDbContext.Carousels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Carousel?> UpdateAsync(Carousel carousel)
        {
            var existingCarousel = await greenoDbContext.Carousels.FirstOrDefaultAsync(x => x.Id == carousel.Id);

            if (existingCarousel != null)
            {
                existingCarousel.Id = carousel.Id;
                existingCarousel.Title = carousel.Title;
                existingCarousel.SubTitle = carousel.SubTitle;
                existingCarousel.Description = carousel.Description;
                existingCarousel.Image = carousel.Image;

                await greenoDbContext.SaveChangesAsync();
                return existingCarousel;
            }

            return null;
        }
    }
}
