using Core.IRepository;
using Core.Models;
using Core.Models.DtosModels;
using Core.Params;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController(IObjectRepository _Irepo):ControllerBase
    {
        [HttpGet("getAllObj")]
        public async Task<IActionResult> GetAll([FromQuery]ObjectSpecParams param)
        {
          var listOfObj = await _Irepo.GetFilterAndAllObj(param);
            return Ok(listOfObj);
        }

        [HttpPost("addObj")]
        public async Task<IActionResult> AddNewObj(AddObjectDtoModel addObject)
        {
            var newObj = await _Irepo.AddObj(addObject);
            return Ok(newObj);
        }

        [HttpPut("updateObj/{id}")]
        public async Task<IActionResult> UpdateObj(int id, ObjectModel update)
        {
            var updateObj = await _Irepo.UpDateObj(id, update);
            return Ok(updateObj);
        }

        [HttpDelete("deleteObj/{id}")]
        public async Task<IActionResult> DeleteObj(int id)
        {
            var del = await _Irepo.DeleteObj(id);
            return Ok(del);
        }

    }
}
