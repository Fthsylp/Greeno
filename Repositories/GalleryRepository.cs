using Greeno.Data;
using Greeno.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Greeno.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly GreenoDbContext greenoDbContext;

        public GalleryRepository(GreenoDbContext greenoDbContext)
        {
            this.greenoDbContext = greenoDbContext;
        }

        public async Task<Gallery?> AddAsync(Gallery gallery)
        {
            await greenoDbContext.AddAsync(gallery);
            await greenoDbContext.SaveChangesAsync();
            return gallery;
        }

        public async Task<Gallery?> DeleteAsync(Guid id)
        {
            var existingGallery = await greenoDbContext.Galleries.FindAsync(id);

            if (existingGallery != null)
            {
                greenoDbContext.Galleries.Remove(existingGallery);
                await greenoDbContext.SaveChangesAsync();
                return existingGallery;
            }
            return null;
        }

        public async Task<IEnumerable<Gallery>> GetAllAsync()
        {
            return await greenoDbContext.Galleries.ToListAsync();
        }

        public async Task<Gallery?> GetByIdAsync(Guid id)
        {
            return await greenoDbContext.Galleries.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Gallery?> UpdateAsync(Gallery gallery)
        {
            var existingGallery = await greenoDbContext.Galleries.FirstOrDefaultAsync(x=>x.Id == gallery.Id);

            if (existingGallery != null) {
                existingGallery.Id = gallery.Id;
                existingGallery.Image = gallery.Image;
            
                await greenoDbContext.SaveChangesAsync();
                return existingGallery;
            }

            return null;

        }
    }
}
