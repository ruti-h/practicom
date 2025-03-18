using Cheers.Core.Entities;


namespace Cheers.Core.IRepository
{
  public  interface IRepositoryMale
    {
        public Task<IEnumerable<Male>> GetListOfMaleAsync();
        public Task<Male> GetMaleByIdAsync(int id);
        public Task<Male> AddMaleAsync(Male male);
        public Task<Male> DeleteMaleAsync(int id);
        public Task<Male> UpdateMaleAsync(int id, Male male);
    }
}
