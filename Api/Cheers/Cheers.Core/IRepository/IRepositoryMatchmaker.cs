﻿

using Cheers.Core.Entities;

namespace Cheers.Core.IRepository
{
    public interface IRepositoryMatchmaker
    {
        public Task<IEnumerable<MatchMaker>> GetListOfMatchMakerAsync();
        public Task<MatchMaker> GetMatchMakerByIdAsync(int id);
        public Task<MatchMaker> AddMatchMakerAsync(MatchMaker matchMaker);
        public Task<MatchMaker> DeleteMatchMakerAsync(int id);
        public Task<MatchMaker> UpdateMatchMakerAsync(int id, MatchMaker matchMaker);
    }
}
