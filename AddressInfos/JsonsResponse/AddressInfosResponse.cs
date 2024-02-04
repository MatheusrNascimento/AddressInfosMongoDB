using System.ComponentModel.DataAnnotations;

namespace AddressInfos.JsonsResponse
{
    public class AddressInfosResponse
    {
        public string Id { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string CEP { get; set; }

        public string State { get; set; }
    }
}
