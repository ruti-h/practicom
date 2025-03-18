using AutoMapper;
using Cheers.Api.Models;
using Cheers.Core.DTOs;
using Cheers.Core.IServices;
using Microsoft.AspNetCore.Mvc;
namespace Cheers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceContacts _contactsService;
        private readonly IMapper _mapper;

        public ContactsController(IServiceContacts contactsService, IMapper mapper)
        {
            _contactsService = contactsService;
            _mapper = mapper;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactsDTOs>>> GetContacts()
        {
            var contacts = await _contactsService.GetListOfContactAsync();
            var contactsDto = _mapper.Map<IEnumerable<ContactsDTOs>>(contacts); // מיפוי כאן
            return Ok(contactsDto);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactsDTOs>> GetContact(int id)
        {
            var contact = await _contactsService.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            var contactDto = _mapper.Map<ContactsDTOs>(contact); // מיפוי כאן
            return Ok(contactDto);
        }

        // POST: api/contacts
        [HttpPost]
        //public async Task<ActionResult<ContactsDTOs>> AddContact([FromBody] ContactsModel contactModel)
        //{
        //    if (contactModel == null)
        //    {
        //        return BadRequest("Contact data is null.");
        //    }

        //    var contact = _mapper.Map<ContactsDTOs>(contactModel); // מיפוי כאן
        //    var addedContact = await _contactsService.AddContactAsync(contact);
        //    var addedContactDto = _mapper.Map<ContactsDTOs>(addedContact); // מיפוי כאן
        //    return CreatedAtAction(nameof(GetContact), new { Name = addedContactDto.Name }, addedContactDto);
        //}
        [HttpPost]
        public async Task<ActionResult<ContactsDTOs>> AddContact([FromBody] ContactsModel contactModel)
        {
            if (contactModel == null)
            {
                return BadRequest("Contact data is null.");
            }

            var contact = _mapper.Map<ContactsDTOs>(contactModel);
            var addedContact = await _contactsService.AddContactAsync(contact);

            var addedContactDto = _mapper.Map<ContactsDTOs>(addedContact);

            // החזרת התוצאה מבלי לכלול את ה-ID
            return CreatedAtAction(nameof(GetContact), new { id = addedContactDto.Id }, new { Name = addedContactDto.Name, Phone = addedContactDto.Phone });
        }
        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactsDTOs>> UpdateContact(int id, [FromBody] ContactsModel contactModel)
        {
            if (contactModel == null)
            {
                return BadRequest("Contact data is null.");
            }

            var contact = _mapper.Map<ContactsDTOs>(contactModel); // מיפוי כאן
            var updatedContact = await _contactsService.UpdateContactAsync(id, contact);
            if (updatedContact == null)
            {
                return NotFound();
            }
            var updatedContactDto = _mapper.Map<ContactsDTOs>(updatedContact); // מיפוי כאן
            return Ok(updatedContactDto);
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactsDTOs>> DeleteContact(int id)
        {
            var deletedContact = await _contactsService.DeleteContactAsync(id);
            if (deletedContact == null)
            {
                return NotFound();
            }
            var deletedContactDto = _mapper.Map<ContactsDTOs>(deletedContact); // מיפוי כאן
            return Ok(deletedContactDto);
        }

    }
}
