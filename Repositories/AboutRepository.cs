using Greeno.Data;
using Greeno.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Greeno.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly GreenoDbContext greenoDbContext;

        public AboutRepository(GreenoDbContext greenoDbContext)
        {
            this.greenoDbContext = greenoDbContext;
        }

        public async Task<About?> AddAsync(About about)
        {
            await greenoDbContext.AddAsync(about);
            await greenoDbContext.SaveChangesAsync();
            return about;
        }

        public async Task<About?> DeleteAsync(Guid id)
        {
            var existingAbout = await greenoDbContext.Abouts.FindAsync(id);

            if (existingAbout != null) 
            {
                greenoDbContext.Abouts.Remove(existingAbout);
                await greenoDbContext.SaveChangesAsync();
                return existingAbout;
            }
            return null;
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await greenoDbContext.Abouts.ToListAsync();
        }

        public async Task<About?> GetByIdAsync(Guid id)
        {
            return await greenoDbContext.Abouts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<About?> UpdateAsync(About about)
        {
            var existingAbout = await greenoDbContext.Abouts.FirstOrDefaultAsync(x=>x.Id == about.Id);

            if (existingAbout != null) 
            {
                existingAbout.Id = about.Id;
                existingAbout.Title = about.Title;
                existingAbout.Description = about.Description;
                existingAbout.Satisfaction = about.Satisfaction;
                existingAbout.FreeDelivery = about.FreeDelivery;
                existingAbout.StoreLocators = about.StoreLocators;

                await greenoDbContext.SaveChangesAsync();
                return existingAbout;
            }

            return null;
        }
    }
}
