using AddressInfoRepository.Entities;
using AddressInfos.Config;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AddressInfoRepository
{
    public class AddressInfosService
    {
        private readonly IMongoCollection<AddressInfo> _addressCollection;

        public AddressInfosService(
            IOptions<AddressDataBaseSettings> addressDataBaseSettings)
        {
            var mongoClient = new MongoClient(
                addressDataBaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                addressDataBaseSettings.Value.DatabaseName);

            _addressCollection = mongoDatabase.GetCollection<AddressInfo>(
                addressDataBaseSettings.Value.AddressColletionName);
        }

        public async Task<List<AddressInfo>> GetAsync() =>
            await _addressCollection.Find(_ => true).ToListAsync();

        public async Task<AddressInfo?> GetAsyncById(ObjectId id) =>
            await _addressCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public void CreateAsync(AddressInfo newBook) =>
             _addressCollection.InsertOne(newBook);

        public async Task UpdateAsync(ObjectId id, AddressInfo updatedBook) =>
            await _addressCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(ObjectId id) =>
            await _addressCollection.DeleteOneAsync(x => x.Id == id);
    }
}
