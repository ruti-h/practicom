
using Cheers.Core.DTOs;

namespace Cheers.Core.IServices
{
    public interface IServiceMatchMaker
    {

        public Task<IEnumerable<MatchMakerDTOs>> GetListOfMatchMakerAsync();
        public Task<MatchMakerDTOs> GetMatchMakerByIdAsync(int id);
        public Task<MatchMakerDTOs> AddMatchMakerAsync(MatchMakerDTOs matchMaker);
        public Task<MatchMakerDTOs> DeleteMatchMakerAsync(int id);
        public Task<MatchMakerDTOs> UpdateMatchMakerAsync(int id, MatchMakerDTOs matchMaker);
    }
}
