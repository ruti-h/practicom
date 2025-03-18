using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
   public class RepositoryContact : IRepositoryContacts
    {
      
            private readonly DataContext _context;

            public RepositoryContact(DataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Contacts>> GetListOfContactAsync()
            {
                return await _context.Contacts.ToListAsync();
            } // קבלת רשימת אנשי קשר

            public async Task<Contacts> GetContactByIdAsync(int id)
            {
                return await _context.Contacts.FindAsync(id);
            }

            public async Task<Contacts> AddContactAsync(Contacts contact)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return contact;
            }

            public async Task<Contacts> DeleteContactAsync(int id)
            {
                var contact = await _context.Contacts.FindAsync(id);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    await _context.SaveChangesAsync();
                }
                return contact;
            }

            //public async Task<Contacts> UpdateContactAsync(int id, Contacts contact)
            //{
            //    var existingContact = await _context.Contacts.FindAsync(id);
            //    if (existingContact != null)
            //    {
            //        existingContact.FirstName = contact.FirstName; // עדכן את המאפיינים הנדרשים
            //        existingContact.LastName = contact.LastName;
            //        // הוסף כאן עדכונים נוספים לפי הצורך

            //        await _context.SaveChangesAsync();
            //    }
            //    return existingContact;
            //}

            public async Task<Contacts> UpdateContactAsync(int id, Contacts contact)
            {
                var existingContact = await _context.Contacts.FindAsync(id);
                if (existingContact != null)
                {
                    existingContact.Name = contact.Name; // עדכון שם
                    existingContact.Phone = contact.Phone; // עדכון טלפון

                    // עדכון הקשרים אם יש צורך
                    if (contact.MaleId.HasValue)
                    {
                        existingContact.MaleId = contact.MaleId;
                    }

                    if (contact.WomenId.HasValue)
                    {
                        existingContact.WomenId = contact.WomenId;
                    }

                    if (contact.MatchMakerId.HasValue)
                    {
                        existingContact.MatchMakerId = contact.MatchMakerId;
                    }

                    await _context.SaveChangesAsync();
                }
                return existingContact;
            }

        }
    }
