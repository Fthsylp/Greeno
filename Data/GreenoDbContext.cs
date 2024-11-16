using Greeno.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Greeno.Data
{
    public class GreenoDbContext : DbContext
    {
        public GreenoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Carousel> Carousels { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<PlantContainer> PlantContainers { get; set; }
    }
}
