using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AliGulmen.Week5.HomeWork.RestfulApi.Services.StorageService;
using Microsoft.AspNetCore.Authorization;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;
using System.Linq;
using System;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Controllers
{
    [Authorize]
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase

    {
        private readonly IContainerRepository _repository;
        private readonly IStorageService _storageService;


        public ContainerController(IContainerRepository repository, IStorageService storageService)
        {
            _repository = repository;
            _storageService = storageService;
        }

        /************************************* GET *********************************************/

        //GET api/containers
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetContainers()
        {
            var result = _repository.GetContainers();
            return Ok(result);
        }

        //GET api/containers/1
        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var result = _repository.GetContainerDetail(id);
            return Ok(result);
        }



        //GET api/containers
        [HttpGet("WithParams")]
        [AllowAnonymous]
        public IActionResult GetContainersWithParameters([FromQuery] QueryParamsModel query)
        {
            var result = _repository.GetContainersWithParameters(query);
            Response.Headers.Add("X-Paging", System.Text.Json.JsonSerializer.Serialize(result.Result));
            return Ok(result);
            
        }








        //GET api/products/list?maxWeight=100
        [ResponseCache(Duration = 1000, Location = ResponseCacheLocation.Any )]
        [HttpGet("list")]
        [AllowAnonymous]
        public IActionResult GetContainersByMaxWeight([FromQuery] int maxWeight)
        {

            var result = _repository.GetContainerListByWeight(maxWeight);
            return Ok(result);
        }




        /************************************* POST *********************************************/



        //POST api/containers
        [HttpPost]
        public IActionResult CreateContainer([FromBody] Container newContainer)
        {

            _repository.CreateContainer(newContainer);
            return Created("~api/containers", newContainer);
        }



        /************************************* PUT *********************************************/


        //PUT api/containers/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Container newContainer)
        {
            _repository.UpdateContainer(newContainer, id);
            return NoContent();

        }


        /************************************* DELETE *********************************************/

        //DELETE api/rotations/id
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _repository.DeleteContainer(id);
            return NoContent();
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateLocation(int id, int locationId)
        {
            _repository.UpdateContainerLocation(id, locationId);
            return NoContent();


        }
    }
}
