using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Controllers
{
	[Authorize]
	[Route("api/[controller]s")]
	[ApiController]
	public class RotationController : ControllerBase
	{

		private readonly IRotationRepository _repository;


		public RotationController(IRotationRepository repository)
		{ 
		_repository = repository;
		}

		/************************************* GET *********************************************/

		//GET api/rotations
		[AllowAnonymous]
		[HttpGet]
		public IActionResult GetRotations()
		{
			var result = _repository.GetRotations();
			return Ok(result);
		}


		//GET api/rotations/1
		[HttpGet("{id}")]
		public IActionResult GetRotationById(int id)
		{
			var result = _repository.GetRotationDetail(id);
			return Ok(result);
		}


		//GET api/rotations/1/Locations
		[AllowAnonymous]
		[HttpGet("{id}/Locations")]
		public IActionResult GetLocationsByRotation(int id)
		{
			var result = _repository.GetRotationLocations(id);
			return Ok(result);
		}


		//GET api/rotations/1/Products
		[AllowAnonymous]
		[HttpGet("{id}/Products")]
		public IActionResult GetProductsByRotation(int id)
		{
			var result = _repository.GetRotationProducts(id);

			return Ok(result);
		}



		/************************************* POST *********************************************/



		//POST api/rotations
		[HttpPost]
		public IActionResult CreateRotation([FromBody] Rotation newRotation)
		{
			_repository.CreateRotation(newRotation);
			return Created("~api/rotations", newRotation); 
		}



		/************************************* PUT *********************************************/


		//PUT api/rotations/id
		[HttpPut("{id}")]
		public IActionResult Update(int id,Rotation newRotation)
		{
			_repository.UpdateRotation( id, newRotation);
			return NoContent(); 
		}


		/************************************* DELETE *********************************************/

		//DELETE api/rotations/id
		[HttpDelete("{id}")]

		public IActionResult Delete(int id)
		{
			_repository.DeleteRotation(id);
			return NoContent(); 
		}



		/************************************* PATCH *********************************************/

		//PATCH api/rotations/id
		[HttpPatch("{id}")]
		public IActionResult UpdateCode(int id, string code)
		{
			_repository.UpdateRotationCode( id, code);
			return NoContent(); 

		}





	}
}
