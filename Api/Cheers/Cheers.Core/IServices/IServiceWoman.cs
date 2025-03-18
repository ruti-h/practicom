
using Cheers.Core.DTOs;

namespace Cheers.Core.IServices
{
   public interface IServiceWoman
    {
        public Task<IEnumerable<WomanDTOs>> GetListOfWomenAsync();
        public Task<WomanDTOs> GetWomenByIdAsync(int id);
        public Task<WomanDTOs> AddWomenAsync(WomanDTOs women);
        public Task<WomanDTOs> DeleteWomenAsync(int id);
        public Task<WomanDTOs> UpdateWomenAsync(int id, WomanDTOs women);
    }
}
