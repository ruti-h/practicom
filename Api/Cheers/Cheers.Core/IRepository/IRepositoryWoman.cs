

using Cheers.Core.Entities;

namespace Cheers.Core.IRepository
{
    public interface IRepositoryWoman
    {
        public Task<IEnumerable<Woman>> GetListOfWomenAsync();
        public Task<Woman> GetWomenByIdAsync(int id);
        public Task<Woman> AddWomenAsync(Woman women);
        public Task<Woman> DeleteWomenAsync(int id);
        public Task<Woman> UpdateWomenAsync(int id, Woman women);

    }
}
