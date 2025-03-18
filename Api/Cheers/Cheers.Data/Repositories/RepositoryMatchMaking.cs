

using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
  public  class RepositoryMatchMaking : IRepositoryMatchMaking
    {
        private readonly DataContext _context;

        public RepositoryMatchMaking(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchMaking>> GetListOfMatchMakingAsync()
        {
            return await _context.MatchMakings
                .Include(mm => mm.Male) // כולל את המידע על הגברים
                .Include(mm => mm.Women) // כולל את המידע על הנשים
                .Include(mm => mm.MatchMaker) // כולל את המידע על השדכנים
                .ToListAsync();
        }

        public async Task<MatchMaking> GetMatchMakingByIdAsync(int id)
        {
            return await _context.MatchMakings
                .Include(mm => mm.Male)
                .Include(mm => mm.Women)
                .Include(mm => mm.MatchMaker)
                .FirstOrDefaultAsync(mm => mm.Id == id);
        }

        public async Task<MatchMaking> AddMatchMakingAsync(MatchMaking matchMaking)
        {
            _context.MatchMakings.Add(matchMaking);
            await _context.SaveChangesAsync();
            return matchMaking;
        }

        public async Task<MatchMaking> DeleteMatchMakingAsync(int id)
        {
            var matchMaking = await _context.MatchMakings.FindAsync(id);
            if (matchMaking != null)
            {
                _context.MatchMakings.Remove(matchMaking);
                await _context.SaveChangesAsync();
            }
            return matchMaking;
        }

        public async Task<MatchMaking> UpdateMatchMakingAsync(int id, MatchMaking matchMaking)
        {
            var existingMatchMaking = await GetMatchMakingByIdAsync(id);
            if (existingMatchMaking != null)
            {
                _context.Entry(existingMatchMaking).CurrentValues.SetValues(matchMaking);
                await _context.SaveChangesAsync();
            }
            return existingMatchMaking;
        }
    }
}
