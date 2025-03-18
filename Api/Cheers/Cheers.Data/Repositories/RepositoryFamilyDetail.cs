
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
    public class RepositoryFamilyDetail : IRepositoryFamilyDetail
    {


        private readonly DataContext _context;

        public RepositoryFamilyDetail(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FamilyDetail>> GetListOfFamilyDetailsAsync()
        {
            return await _context.FamilyDetails.ToListAsync();
        }

        public async Task<FamilyDetail> GetFamilyDetailsByIdAsync(int id)
        {
            return await _context.FamilyDetails.FindAsync(id);
        }

        public async Task<FamilyDetail> AddFamilyDetailsAsync(FamilyDetail familyDetails)
        {
            _context.FamilyDetails.Add(familyDetails);
            await _context.SaveChangesAsync();
            return familyDetails;
        }

        public async Task<FamilyDetail> DeleteFamilyDetailsAsync(int id)
        {
            var familyDetail = await _context.FamilyDetails.FindAsync(id);
            if (familyDetail != null)
            {
                _context.FamilyDetails.Remove(familyDetail);
                await _context.SaveChangesAsync();
            }
            return familyDetail;
        }
        public async Task<FamilyDetail> UpdateFamilyDetailsAsync(int id, FamilyDetail familyDetails)
        {
            await DeleteFamilyDetailsAsync(id); // מחיקת פרטי המשפחה הקיימים
            await _context.SaveChangesAsync(); // שמירה על השינויים

            // הוספת פרטי המשפחה החדשים
            return await AddFamilyDetailsAsync(familyDetails);
        }

    }
}
