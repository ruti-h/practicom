

using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
  public  class RepositortWoman : IRepositoryWoman
    {
   
            private readonly DataContext _context;

            public RepositortWoman(DataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Woman>> GetListOfWomenAsync()
            {
                return await _context.Womens
                    .Include(w => w.Matchings) // כולל את המידע על השידוכים הקשורים
                    .ToListAsync();
            }

            public async Task<Woman> GetWomenByIdAsync(int id)
            {
                return await _context.Womens
                    .Include(w => w.Matchings)
                    .FirstOrDefaultAsync(w => w.Id == id);
            }

            public async Task<Woman> AddWomenAsync(Woman women)
            {
                _context.Womens.Add(women);
                await _context.SaveChangesAsync();
                return women;
            }

            public async Task<Woman> DeleteWomenAsync(int id)
            {
                var woman = await _context.Womens.FindAsync(id);
                if (woman != null)
                {
                    _context.Womens.Remove(woman);
                    await _context.SaveChangesAsync();
                }
                return woman;
            }

            public async Task<Woman> UpdateWomenAsync(int id, Woman women)
            {
                var existingWoman = await GetWomenByIdAsync(id);
                if (existingWoman != null)
                {
                    _context.Entry(existingWoman).CurrentValues.SetValues(women);
                    await _context.SaveChangesAsync();
                }
                return existingWoman;
            }
        }
    }

