

using Cheers.Core.DTOs;

namespace Cheers.Core.IServices
{
   public interface IServiceFamiltDetail
    {
        public Task<IEnumerable<FamilyDetailDTOs>> GetListOfFamilyDetailsAsync();
        public Task<FamilyDetailDTOs> GetFamilyDetailsByIdAsync(int id);
        public Task<FamilyDetailDTOs> AddFamilyDetailsAsync(FamilyDetailDTOs familyDetails);
        public Task<FamilyDetailDTOs> DeleteFamilyDetailsAsync(int id);
        public Task<FamilyDetailDTOs> UpdateFamilyDetailsAsync(int id, FamilyDetailDTOs FamilyDetails);
    }
}
