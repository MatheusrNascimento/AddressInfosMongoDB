using AddressInfoRepository;
using AddressInfoRepository.Entities;
using AddressInfos.JsonsResponse;
using AddressInfos.Mapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AddressInfos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressInfosService _addressService;

        public AddressController(AddressInfosService addressService) =>
            _addressService = addressService;

        [HttpPut(Name = "InsertAddress")]
        public IActionResult InsertAddress(JsonAddressInfo address)
        {
            AddressInfo addressInfo = AddressInfoMapper.AddressInfosInsertMapper(address);

            _addressService.CreateAsync(addressInfo);

            return Ok(new { Id = addressInfo.Id.ToString() });
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<AddressInfo>> GetAddress(string id)
        {
            ObjectId addressInfoId = new ObjectId(id);

            AddressInfo addressInfos = await _addressService.GetAsync(addressInfoId);

            if (addressInfos == null)
                return NoContent();

            AddressInfosResponse response = AddressInfoMapper.AddressInfosResponseMapper(addressInfos);

            return Ok(response);
        }
    }
}
