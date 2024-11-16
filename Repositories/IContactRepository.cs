using Greeno.Models.Domain;

namespace Greeno.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();

        Task<Contact?> GetByIdAsync(Guid id);

        Task<Contact?> AddAsync(Contact contact);

        Task<Contact?> UpdateAsync(Contact contact);

        Task<Contact?> DeleteAsync(Guid id);
    }
}
