
using Cheers.Core.DTOs;

namespace Cheers.Core.IServices
{
   public interface IServiceMatchMaking
    {
        public Task<IEnumerable<MatchMakingDTOs>> GetListOfMatchMakingAsync();
        public Task<MatchMakingDTOs> GetMatchMakingByIdAsync(int id);
        public Task<MatchMakingDTOs> AddMatchMakingAsync(MatchMakingDTOs matchMaking);
        public Task<MatchMakingDTOs> DeleteMatchMakingAsync(int id);
        public Task<MatchMakingDTOs> UpdateMatchMakingAsync(int id, MatchMakingDTOs women);

    }
}
