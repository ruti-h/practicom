using Cheers.Core.Entities;
namespace Cheers.Core.IRepository
{
 public   interface IRepositoryContacts
    {
        public Task<IEnumerable<Contacts>> GetListOfContactAsync();
        public Task<Contacts> GetContactByIdAsync(int id);
        public Task<Contacts> AddContactAsync(Contacts contact);
        public Task<Contacts> DeleteContactAsync(int id);
        public Task<Contacts> UpdateContactAsync(int id, Contacts contact);
    }
}
