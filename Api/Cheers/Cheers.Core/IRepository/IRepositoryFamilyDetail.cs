

using Cheers.Core.Entities;

namespace Cheers.Core.IRepository
{
   public interface IRepositoryFamilyDetail
    {
        public Task<IEnumerable<FamilyDetail>> GetListOfFamilyDetailsAsync();
        public Task<FamilyDetail> GetFamilyDetailsByIdAsync(int id);
        public Task<FamilyDetail> AddFamilyDetailsAsync(FamilyDetail familyDetails);
        public Task<FamilyDetail> DeleteFamilyDetailsAsync(int id);
        public Task<FamilyDetail> UpdateFamilyDetailsAsync(int id, FamilyDetail FamilyDetails);
    }
}
