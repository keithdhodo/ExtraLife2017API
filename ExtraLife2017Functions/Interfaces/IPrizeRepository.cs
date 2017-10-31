using ExtraLife2017Functions.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtraLife2017Functions.Interfaces
{
    public interface IPrizeRepository
    {
        IMongoDatabase Database { get; }
        string MongoDbConnectionString { get; set; }

        IMongoDatabase InitializeMongoDb();

        Task InsertTheInitialData();

        IEnumerable<Prize> Create();
        Task<IEnumerable<Prize>> RetrieveAsync();
        Task<IEnumerable<Prize>> SaveAsync(Prize product);
        Task<IEnumerable<Prize>> SaveAsync(int id, Prize product);
        Task<bool> WriteDataAsync(List<Prize> products, bool isUpdate = false);
    }
}
