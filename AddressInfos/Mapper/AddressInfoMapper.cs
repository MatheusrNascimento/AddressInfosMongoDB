using AddressInfoRepository.Entities;
using AddressInfos.JsonsResponse;

namespace AddressInfos.Mapper
{
    public class AddressInfoMapper
    {

        public static AddressInfo AddressInfosInsertMapper(JsonAddressInfo jsonAddressInfo)
        {
            AddressInfo addressInfo = new()
            {
                Street = jsonAddressInfo.Street,
                CEP = jsonAddressInfo.CEP,
                State = jsonAddressInfo.State,
                Neighborhood = jsonAddressInfo.Neighborhood
            };

            return addressInfo;
        }

        public static AddressInfosResponse AddressInfosResponseMapper(AddressInfo addressInfo)
        {
            AddressInfosResponse addressInfosResponse = new()
            {
                Id = addressInfo.Id.ToString(),
                Street = addressInfo.Street,
                CEP = addressInfo.CEP,
                State = addressInfo.State,
                Neighborhood = addressInfo.Neighborhood
            };

            return addressInfosResponse;
        }

        public static AddressInfo AddresInfosUpdateMapper(JsonAddressInfo jsonAddressInfo)
        {
            AddressInfo addressInfo = new()
            {
                Id = new MongoDB.Bson.ObjectId(jsonAddressInfo.Id),
                Street = jsonAddressInfo.Street,
                CEP = jsonAddressInfo.CEP,
                State = jsonAddressInfo.State,
                Neighborhood = jsonAddressInfo.Neighborhood
            };

            return addressInfo;
        }
    }
}
