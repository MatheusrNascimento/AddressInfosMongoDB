using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace AddressInfos
{
    public class JsonAddressInfo
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string State { get; set; }
    }
}
