using Infra;
using Mappers;
using Models;

namespace Services
{
    public interface IKnightsService
    {
        Task Create(CreateKnightRequest knight);
        Task<bool> Update(string id, UpdateKnightRequest knight);
        Task<bool> Delete(string id);
        Task<Knight> GetById(string id);
        Task<IEnumerable<Knight>> GetAll(string filter);
        Task<bool> Inactivate(string id);
    }
}