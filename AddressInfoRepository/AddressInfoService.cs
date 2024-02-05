using AddressInfoRepository.Entities;
using AddressInfoRepository.Utils;
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

        public async Task<List<AddressInfo>> GetAsync()
        {
            try
            {
                return await _addressCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddressInfo?> GetAsyncById(ObjectId id) =>
            await _addressCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public void CreateAsync(AddressInfo newAddres)
        {
            try
            {
                _addressCollection.InsertOne(newAddres);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(AddressInfo addressInfosUpdate)
        {
            try
            {
                var response = await _addressCollection.ReplaceOneAsync(x => x.Id == addressInfosUpdate.Id, addressInfosUpdate);


                if (!response.IsModifiedCountAvailable)
                    throw new Exception(ServiceErrorMsg.EXC001);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(ObjectId id) =>
            await _addressCollection.DeleteOneAsync(x => x.Id == id);
    }
}
