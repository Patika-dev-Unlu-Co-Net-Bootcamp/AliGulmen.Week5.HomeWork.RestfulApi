using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Controllers
{
    [Authorize]
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase


    {
        private readonly IProductRepository _repository;
       


        public ProductController(IProductRepository repository)
        {
            _repository = repository;
            
        }

        /************************************* GET *********************************************/

        //GET api/products
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _repository.GetProducts();
            return Ok(result);
        }



        //GET api/products/1
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _repository.GetProductDetail(id);
            return Ok(result);
        }

        //GET api/products/1/Containers
        [HttpGet("{id}/Containers")]
        public IActionResult GetContainersByProduct(int id)
        {
            var result = _repository.GetProductContainers(id);
            return Ok(result);
        }


        //GET api/products/list?rotationId=1
        [HttpGet("list")]
        public IActionResult GetProductsByRotation([FromQuery] int rotationId)
        {

            var result = _repository.GetProductListByRotation(rotationId);
            return Ok(result);
        }


        /************************************* POST *********************************************/



        //POST api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            _repository.CreateProduct(newProduct);
            return Created("~api/products", newProduct);
        }



        /************************************* PUT *********************************************/


        //PUT api/products/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product newProduct)
        {

            _repository.UpdateProduct(id, newProduct);
            return NoContent();
        }


        /************************************* DELETE *********************************************/


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return NoContent();
        }



        /************************************* PATCH *********************************************/

        //PATCH api/products/id
        [HttpPatch("{id}")]
        [AllowAnonymous]
        public IActionResult UpdateAvailability(int id, bool isActive)
        {
            _repository.UpdateProductAvailability(id, isActive);
            return NoContent();

        }






    }
}
