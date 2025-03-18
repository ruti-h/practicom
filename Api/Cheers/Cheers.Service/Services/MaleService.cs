

using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;

namespace Cheers.Service.Services
{
    public class MaleService : IServiceMale
    {
        private readonly IRepositoryMale _maleRepository;
        private readonly IMapper _mapper;

        public MaleService(IRepositoryMale maleRepository, IMapper mapper)
        {
            _maleRepository = maleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaleDTOs>> GetListOfMaleAsync()
        {
            var males = await _maleRepository.GetListOfMaleAsync();
            return _mapper.Map<IEnumerable<MaleDTOs>>(males);
        }

        public async Task<MaleDTOs> GetMaleByIdAsync(int id)
        {
            var male = await _maleRepository.GetMaleByIdAsync(id);
            return _mapper.Map<MaleDTOs>(male);
        }

        public async Task<MaleDTOs> AddMaleAsync(MaleDTOs maleDto)
        {
            var male = _mapper.Map<Male>(maleDto);
            var addedMale = await _maleRepository.AddMaleAsync(male);
            return _mapper.Map<MaleDTOs>(addedMale);
        }

        public async Task<MaleDTOs> DeleteMaleAsync(int id)
        {
            var deletedMale = await _maleRepository.DeleteMaleAsync(id);
            return _mapper.Map<MaleDTOs>(deletedMale);
        }

        public async Task<MaleDTOs> UpdateMaleAsync(int id, MaleDTOs maleDto)
        {
            var male = _mapper.Map<Male>(maleDto);
            var updatedMale = await _maleRepository.UpdateMaleAsync(id, male);
            return _mapper.Map<MaleDTOs>(updatedMale);
        }
    }
}
