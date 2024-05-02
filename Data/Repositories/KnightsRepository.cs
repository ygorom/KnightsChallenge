using Infra;
using Models;
using MongoDB.Driver;

namespace Data.Repositories
{
    public class KnightsRepository(IMongoDbContext context) : IKnightsRepository
    {
        private readonly IMongoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task CreateAsync(Knight knight) =>
            await _context.Knights.InsertOneAsync(knight);

        public async Task<bool> UpdateAsync(Knight knight)
        {
            ReplaceOneResult updateResult = await _context.Knights.ReplaceOneAsync(
                               filter: k => k.Id == knight.Id, replacement: knight);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Knight> filter = Builders<Knight>.Filter.Eq(k => k.Id, id);
            DeleteResult deleteResult = await _context.Knights.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Knight> GetByIdAsync(string id) =>
            await _context.Knights.Find(k => k.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Knight>> GetAllAsync() =>
            await _context.Knights.Find(k => true).ToListAsync();
    }
}