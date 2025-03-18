
using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;

namespace Cheers.Service.Services
{
 public   class MatchMakerService: IServiceMatchMaker
    {
        private readonly IRepositoryMatchmaker _matchMakerRepository;
        private readonly IMapper _mapper;

        public MatchMakerService(IRepositoryMatchmaker matchMakerRepository, IMapper mapper)
        {
            _matchMakerRepository = matchMakerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchMakerDTOs>> GetListOfMatchMakerAsync()
        {
            var matchMakers = await _matchMakerRepository.GetListOfMatchMakerAsync();
            return _mapper.Map<IEnumerable<MatchMakerDTOs>>(matchMakers);
        }

        public async Task<MatchMakerDTOs> GetMatchMakerByIdAsync(int id)
        {
            var matchMaker = await _matchMakerRepository.GetMatchMakerByIdAsync(id);
            return _mapper.Map<MatchMakerDTOs>(matchMaker);
        }

        public async Task<MatchMakerDTOs> AddMatchMakerAsync(MatchMakerDTOs matchMakerDto)
        {
            var matchMaker = _mapper.Map<MatchMaker>(matchMakerDto);
            var addedMatchMaker = await _matchMakerRepository.AddMatchMakerAsync(matchMaker);
            return _mapper.Map<MatchMakerDTOs>(addedMatchMaker);
        }

        public async Task<MatchMakerDTOs> DeleteMatchMakerAsync(int id)
        {
            var deletedMatchMaker = await _matchMakerRepository.DeleteMatchMakerAsync(id);
            return _mapper.Map<MatchMakerDTOs>(deletedMatchMaker);
        }

        public async Task<MatchMakerDTOs> UpdateMatchMakerAsync(int id, MatchMakerDTOs matchMakerDto)
        {
            var matchMaker = _mapper.Map<MatchMaker>(matchMakerDto);
            var updatedMatchMaker = await _matchMakerRepository.UpdateMatchMakerAsync(id, matchMaker);
            return _mapper.Map<MatchMakerDTOs>(updatedMatchMaker);
        }
    }
}
