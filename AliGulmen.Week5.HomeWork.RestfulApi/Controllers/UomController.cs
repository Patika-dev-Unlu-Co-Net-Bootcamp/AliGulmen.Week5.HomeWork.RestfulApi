using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Controllers
{
	[Authorize]
	[Route("api/[controller]s")]
	[ApiController]
	public class UomController : ControllerBase
	{


		private readonly IUomRepository _repository;

		public UomController(IUomRepository repository)
		{
			_repository = repository;
		}



		/************************************* GET *********************************************/






		//GET api/uoms
		[AllowAnonymous]
		[HttpGet]
		public IActionResult GetUoms()
		{
			var result = _repository.GetUoms();
			return Ok(result);
		}



		//GET api/uoms/1
		[HttpGet("{id}")]
		public IActionResult GetUomById(int id)
		{

			var result = _repository.GetUomDetail(id);
			return Ok(result);
		}





		/************************************* POST *********************************************/


		//POST api/uoms
		[HttpPost]
		public IActionResult CreateUom([FromBody] Uom newUom)
		{

			_repository.CreateUom(newUom);
			return Created("~api/uoms", newUom);  
		}



		/************************************* PUT *********************************************/


		//PUT api/uoms/id
		[HttpPut("{id}")]
		public IActionResult Update(int id, Uom newUom)
		{

			_repository.UpdateUom(id, newUom);
			return NoContent(); 

		}

		/************************************* DELETE *********************************************/



		//DELETE api/uoms/id
		[HttpDelete("{id}")]

		public IActionResult Delete(int id)
		{
			_repository.DeleteUom(id);
			return NoContent(); 
		}



		/************************************* PATCH *********************************************/


		//PATCH api/uoms/id
		[HttpPatch("{id}")]
		public IActionResult UpdateDescription(int id, string description)
		{
			_repository.UpdateUomDescription(id,description);
			return NoContent();
		}
	}
}
