

using Cheers.Core.DTOs;

namespace Cheers.Core.IServices
{
   public interface IServiceContacts
    {
        public Task<IEnumerable<ContactsDTOs>> GetListOfContactAsync();
        public Task<ContactsDTOs> GetContactByIdAsync(int id);
        public Task<ContactsDTOs> AddContactAsync(ContactsDTOs contact);
        public Task<ContactsDTOs> DeleteContactAsync(int id);
        public Task<ContactsDTOs> UpdateContactAsync(int id, ContactsDTOs contact);
       
    }
}
