using Greeno.Data;
using Greeno.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Greeno.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly GreenoDbContext greenoDbContext;

        public ContactRepository(GreenoDbContext greenoDbContext)
        {
            this.greenoDbContext = greenoDbContext;
        }

        public async Task<Contact?> AddAsync(Contact contact)
        {
            await greenoDbContext.AddAsync(contact);
            await greenoDbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact?> DeleteAsync(Guid id)
        {
            var existingContact = await greenoDbContext.Contacts.FindAsync(id);

            if (existingContact != null) {
                greenoDbContext.Contacts.Remove(existingContact);
                await greenoDbContext.SaveChangesAsync();
                return existingContact;
            }
            return null;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await greenoDbContext.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await greenoDbContext.Contacts.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Contact?> UpdateAsync(Contact contact)
        {
            var existingContact = await greenoDbContext.Contacts.FirstOrDefaultAsync(x=>x.Id == contact.Id);

            if (existingContact != null) 
            {
                existingContact.Id = contact.Id;
                existingContact.Title = contact.Title;
                existingContact.Image = contact.Image;

                await greenoDbContext.SaveChangesAsync();
                return existingContact;
            }
            return null;
        }
    }
}
