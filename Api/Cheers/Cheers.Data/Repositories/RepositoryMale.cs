

using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
    public class RepositoryMale:IRepositoryMale
    {
        private readonly DataContext _context;

        public RepositoryMale(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Male>> GetListOfMaleAsync()
        {
            return await _context.Males.ToListAsync();
        }

        public async Task<Male> GetMaleByIdAsync(int id)
        {
            return await _context.Males.FindAsync(id);
        }

        public async Task<Male> AddMaleAsync(Male male)
        {
            _context.Males.Add(male);
            await _context.SaveChangesAsync();
            return male;
        }

        public async Task<Male> DeleteMaleAsync(int id)
        {
            var male = await _context.Males.FindAsync(id);
            if (male != null)
            {
                _context.Males.Remove(male);
                await _context.SaveChangesAsync();
            }
            return male;
        }

        public async Task<Male> UpdateMaleAsync(int id, Male male)
        {
            await DeleteMaleAsync(id); // מחיקת המודל הקיים
            await _context.SaveChangesAsync(); // שמירה על השינויים
            return await AddMaleAsync(male); // הוספת המודל החדש
        }
    }
}
