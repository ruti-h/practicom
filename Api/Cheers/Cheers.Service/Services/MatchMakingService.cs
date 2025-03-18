using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;


namespace Cheers.Service.Services
{
  public  class MatchMakingService:IServiceMatchMaking
    {
        private readonly IRepositoryMatchMaking _matchMakingRepository;
        private readonly IMapper _mapper;

        public MatchMakingService(IRepositoryMatchMaking matchMakingRepository, IMapper mapper)
        {
            _matchMakingRepository = matchMakingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchMakingDTOs>> GetListOfMatchMakingAsync()
        {
            var matchMakings = await _matchMakingRepository.GetListOfMatchMakingAsync();
            return _mapper.Map<IEnumerable<MatchMakingDTOs>>(matchMakings);
        }

        public async Task<MatchMakingDTOs> GetMatchMakingByIdAsync(int id)
        {
            var matchMaking = await _matchMakingRepository.GetMatchMakingByIdAsync(id);
            return _mapper.Map<MatchMakingDTOs>(matchMaking);
        }

        public async Task<MatchMakingDTOs> AddMatchMakingAsync(MatchMakingDTOs matchMakingDto)
        {
            var matchMaking = _mapper.Map<MatchMaking>(matchMakingDto);
            var addedMatchMaking = await _matchMakingRepository.AddMatchMakingAsync(matchMaking);
            return _mapper.Map<MatchMakingDTOs>(addedMatchMaking);
        }

        public async Task<MatchMakingDTOs> DeleteMatchMakingAsync(int id)
        {
            var deletedMatchMaking = await _matchMakingRepository.DeleteMatchMakingAsync(id);
            return _mapper.Map<MatchMakingDTOs>(deletedMatchMaking);
        }

        public async Task<MatchMakingDTOs> UpdateMatchMakingAsync(int id, MatchMakingDTOs matchMakingDto)
        {
            var matchMaking = _mapper.Map<MatchMaking>(matchMakingDto);
            var updatedMatchMaking = await _matchMakingRepository.UpdateMatchMakingAsync(id, matchMaking);
            return _mapper.Map<MatchMakingDTOs>(updatedMatchMaking);
        }
    }
}
