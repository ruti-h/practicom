using Cheers.Core.Entities;


namespace Cheers.Core.IRepository
{
    public interface IRepositoryMatchMaking
    {
        public Task<IEnumerable<MatchMaking>> GetListOfMatchMakingAsync();
        public Task<MatchMaking> GetMatchMakingByIdAsync(int id);
        public Task<MatchMaking> AddMatchMakingAsync(MatchMaking matchMaking);
        public Task<MatchMaking> DeleteMatchMakingAsync(int id);
        public Task<MatchMaking> UpdateMatchMakingAsync(int id, MatchMaking matchMaking);
    }
}
