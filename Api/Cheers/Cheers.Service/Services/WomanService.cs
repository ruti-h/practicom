using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.Service.Services
{
   public class WomanService:IServiceWoman
    {
        private readonly IRepositoryWoman _womanRepository;
        private readonly IMapper _mapper;

        public WomanService(IRepositoryWoman womanRepository, IMapper mapper)
        {
            _womanRepository = womanRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WomanDTOs>> GetListOfWomenAsync()
        {
            var women = await _womanRepository.GetListOfWomenAsync();
            return _mapper.Map<IEnumerable<WomanDTOs>>(women);
        }

        public async Task<WomanDTOs> GetWomenByIdAsync(int id)
        {
            var woman = await _womanRepository.GetWomenByIdAsync(id);
            return _mapper.Map<WomanDTOs>(woman);
        }

        public async Task<WomanDTOs> AddWomenAsync(WomanDTOs womenDto)
        {
            var woman = _mapper.Map<Woman>(womenDto);
            var addedWoman = await _womanRepository.AddWomenAsync(woman);
            return _mapper.Map<WomanDTOs>(addedWoman);
        }

        public async Task<WomanDTOs> DeleteWomenAsync(int id)
        {
            var deletedWoman = await _womanRepository.DeleteWomenAsync(id);
            return _mapper.Map<WomanDTOs>(deletedWoman);
        }

        public async Task<WomanDTOs> UpdateWomenAsync(int id, WomanDTOs womenDto)
        {
            var woman = _mapper.Map<Woman>(womenDto);
            var updatedWoman = await _womanRepository.UpdateWomenAsync(id, woman);
            return _mapper.Map<WomanDTOs>(updatedWoman);
        }
    }
}
