using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Controllers
{
    [Authorize]
    [Route("api/[controller]s")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _repository;
        public LocationController(ILocationRepository repository)
        {
            _repository = repository;
        }

        /************************************* GET *********************************************/

        //GET api/locations
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetLocations()
        {
            var result = _repository.GetLocations();
            return Ok(result);
        }



        //GET api/locations/1
        [HttpGet("{id}")]
        public IActionResult LocationById(int id)
        {
            var result = _repository.GetLocationDetail(id);
            return Ok(result);
        }



        //GET api/products/list?rotationId=1
        [HttpGet("list")]
        public IActionResult GetProductsByRotation([FromQuery] int rotationId)
        {

            var result = _repository.GetLocationListByRotation(rotationId);
            return Ok(result);
        }




        /************************************* POST *********************************************/



        //POST api/locations
        [HttpPost]
        public IActionResult CreateLocation([FromBody] Location newLocation)
        {

            _repository.CreateLocation(newLocation);
            return Created("~api/locations", newLocation);
        }



        /************************************* PUT *********************************************/


        //PUT api/locations/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Location newLocation)
        {

            _repository.UpdateLocation(id, newLocation);
            return NoContent();

        }


        /************************************* DELETE *********************************************/

        //DELETE api/locations/id
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _repository.DeleteLocation(id);
            return NoContent();
        }



        /************************************* PATCH *********************************************/

        //PATCH api/locations/id
        [HttpPatch("{id}")]
        public IActionResult UpdateRotation(int id, int rotationId)
        {
            _repository.UpdateLocationRotation(id, rotationId);
            return NoContent();


        }
    }
}
