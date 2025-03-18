

using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
  public  class RepositoryMatchMaker:IRepositoryMatchmaker
    {
        private readonly DataContext _context;

        public RepositoryMatchMaker(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchMaker>> GetListOfMatchMakerAsync()
        {
            return await _context.MatchMakers.ToListAsync();
        }

        public async Task<MatchMaker> GetMatchMakerByIdAsync(int id)
        {
            return await _context.MatchMakers.FindAsync(id);
        }

        public async Task<MatchMaker> AddMatchMakerAsync(MatchMaker matchMaker)
        {
            _context.MatchMakers.Add(matchMaker);
            await _context.SaveChangesAsync();
            return matchMaker;
        }

        public async Task<MatchMaker> DeleteMatchMakerAsync(int id)
        {
            var matchMaker = await _context.MatchMakers.FindAsync(id);
            if (matchMaker != null)
            {
                _context.MatchMakers.Remove(matchMaker);
                await _context.SaveChangesAsync();
            }
            return matchMaker;
        }

        public async Task<MatchMaker> UpdateMatchMakerAsync(int id, MatchMaker matchMaker)
        {
            await DeleteMatchMakerAsync(id); // מחיקת המודל הקיים
            await _context.SaveChangesAsync(); // שמירה על השינויים
            return await AddMatchMakerAsync(matchMaker); // הוספת המודל החדש
        }

    }
}
