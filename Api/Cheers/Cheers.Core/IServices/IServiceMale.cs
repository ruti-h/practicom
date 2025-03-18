



using Cheers.Core.DTOs;

namespace Cheers.Core.IServices
{
  public  interface IServiceMale
    {
        public Task<IEnumerable<MaleDTOs>> GetListOfMaleAsync();
        public Task<MaleDTOs> GetMaleByIdAsync(int id);
        public Task<MaleDTOs> AddMaleAsync(MaleDTOs male);
        public Task<MaleDTOs> DeleteMaleAsync(int id);
        public Task<MaleDTOs> UpdateMaleAsync(int id, MaleDTOs male);
    }
}
