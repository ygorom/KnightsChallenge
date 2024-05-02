using Models;

namespace Data.Repositories
{
    public interface IKnightsRepository
    {
        Task CreateAsync(Knight knight);
        Task<bool> UpdateAsync(Knight knight);
        Task<bool> DeleteAsync(string id);
        Task<Knight> GetByIdAsync(string id);
        Task<IEnumerable<Knight>> GetAllAsync();
    }
}