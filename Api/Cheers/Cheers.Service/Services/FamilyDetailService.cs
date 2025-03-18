

using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;

namespace Cheers.Service.Services
{
    public class FamilyDetailService : IServiceFamiltDetail
    {
            private readonly IRepositoryFamilyDetail _familyDetailRepository;
            private readonly IMapper _mapper;

            public FamilyDetailService(IRepositoryFamilyDetail familyDetailRepository, IMapper mapper)
            {
                _familyDetailRepository = familyDetailRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<FamilyDetailDTOs>> GetListOfFamilyDetailsAsync()
            {
                var familyDetails = await _familyDetailRepository.GetListOfFamilyDetailsAsync();
                return _mapper.Map<IEnumerable<FamilyDetailDTOs>>(familyDetails);
            }

            public async Task<FamilyDetailDTOs> GetFamilyDetailsByIdAsync(int id)
            {
                var familyDetail = await _familyDetailRepository.GetFamilyDetailsByIdAsync(id);
                return _mapper.Map<FamilyDetailDTOs>(familyDetail);
            }

            public async Task<FamilyDetailDTOs> AddFamilyDetailsAsync(FamilyDetailDTOs familyDetailsDto)
            {
                var familyDetail = _mapper.Map<FamilyDetail>(familyDetailsDto);
                var addedFamilyDetail = await _familyDetailRepository.AddFamilyDetailsAsync(familyDetail);
                return _mapper.Map<FamilyDetailDTOs>(addedFamilyDetail);
            }

            public async Task<FamilyDetailDTOs> DeleteFamilyDetailsAsync(int id)
            {
                var deletedFamilyDetail = await _familyDetailRepository.DeleteFamilyDetailsAsync(id);
                return _mapper.Map<FamilyDetailDTOs>(deletedFamilyDetail);
            }

            public async Task<FamilyDetailDTOs> UpdateFamilyDetailsAsync(int id, FamilyDetailDTOs familyDetailsDto)
            {
                var familyDetail = _mapper.Map<FamilyDetail>(familyDetailsDto);
                var updatedFamilyDetail = await _familyDetailRepository.UpdateFamilyDetailsAsync(id, familyDetail);
                return _mapper.Map<FamilyDetailDTOs>(updatedFamilyDetail);
            }
        }
    }


