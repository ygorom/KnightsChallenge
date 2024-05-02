using MongoDB.Driver;
using Models;

namespace Infra
{
    public interface IMongoDbContext
    {
        IMongoCollection<Knight> Knights { get; }
    }
}