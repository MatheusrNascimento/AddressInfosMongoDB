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
        public async Task<ActionResult<AddressInfosResponse>> GetAddressById(string id)
        {
            ObjectId addressInfoId = new ObjectId(id);

            AddressInfo addressInfos = await _addressService.GetAsyncById(addressInfoId);

            if (addressInfos == null)
                return NoContent();

            AddressInfosResponse response = AddressInfoMapper.AddressInfosResponseMapper(addressInfos);

            return Ok(response);
        }

        [HttpPost(Name = "UpdateAddressById")]
        public async Task<ActionResult<AddressInfosResponse>> UpdateAddressById(JsonAddressInfo jsonAddressInfo)
        {
            AddressInfo addressInfo = AddressInfoMapper.AddresInfosUpdateMapper(jsonAddressInfo);

            _addressService.UpdateAsync(addressInfo);

            return Ok();
        }
    }
}
