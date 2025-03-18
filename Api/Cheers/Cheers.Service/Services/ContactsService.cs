
using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;

namespace Cheers.Service.Services
{
    public class ContactsService : IServiceContacts
    {

        private readonly IRepositoryContacts _contactsRepository;
        private readonly IMapper _mapper;

        public ContactsService(IRepositoryContacts contactsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactsDTOs>> GetListOfContactAsync()
        {
            var contacts = await _contactsRepository.GetListOfContactAsync();
            return _mapper.Map<IEnumerable<ContactsDTOs>>(contacts);
        }

        public async Task<ContactsDTOs> GetContactByIdAsync(int id)
        {
            var contact = await _contactsRepository.GetContactByIdAsync(id);
            return _mapper.Map<ContactsDTOs>(contact);
        }

        public async Task<ContactsDTOs> AddContactAsync(ContactsDTOs contactDto)
        {
            var contact = _mapper.Map<Contacts>(contactDto);
            var addedContact = await _contactsRepository.AddContactAsync(contact);
            return _mapper.Map<ContactsDTOs>(addedContact);
        }

        public async Task<ContactsDTOs> DeleteContactAsync(int id)
        {
            var deletedContact = await _contactsRepository.DeleteContactAsync(id);
            return _mapper.Map<ContactsDTOs>(deletedContact);
        }

        public async Task<ContactsDTOs> UpdateContactAsync(int id, ContactsDTOs contactDto)
        {
            var contact = _mapper.Map<Contacts>(contactDto);
            var updatedContact = await _contactsRepository.UpdateContactAsync(id, contact);
            return _mapper.Map<ContactsDTOs>(updatedContact);
        }
    }
}
