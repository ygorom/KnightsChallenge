
using Data.Repositories;
using Infra;
using Mappers;
using Models;

namespace Services
{
    public class KnightsService(IKnightsRepository knightsRepository) : IKnightsService
    {
        private readonly IKnightsRepository _repository = knightsRepository ?? throw new ArgumentNullException(nameof(knightsRepository));

        public async Task Create(CreateKnightRequest request)
        {
            if (request.Weapons?.Where(w => w.Equipped).Count() > 1)
                throw new Exception("A knight can only have one weapon equipped");

            Knight knight = new()
            {
                Name = request.Name,
                Nickname = request.Nickname,
                Birthday = request.Birthday,
                Weapons = request.Weapons,
                Attributes = request.Attributes,
                KeyAttribute = request.KeyAttribute
            };

            await _repository.CreateAsync(knight);
        }

        public async Task<bool> Update(string id, UpdateKnightRequest request)
        {
            var knight = await _repository.GetByIdAsync(id) ?? null;

            if (knight is null)
                return false;

            knight.Nickname = request.Nickname ?? string.Empty;

            return await _repository.UpdateAsync(knight);
        }

        public async Task<bool> Delete(string id) =>
            await _repository.DeleteAsync(id);

        public async Task<Knight> GetById(string id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Knight>> GetAll(string filter)
        {
            var knights = await _repository.GetAllAsync() ?? Enumerable.Empty<Knight>();

            var isHero = string.Equals("Heroes", filter, StringComparison.OrdinalIgnoreCase);

            return knights.Where(knight => knight.IsActive && ((knight.IsHero.Equals(isHero)) || string.IsNullOrEmpty(filter)));
        }

        public async Task<bool> Inactivate(string id)
        {
            var knight = await _repository.GetByIdAsync(id) ?? null;

            if (knight is null)
                return false;

            knight.IsActive = false;

            return await _repository.UpdateAsync(knight);
        }
    }
}