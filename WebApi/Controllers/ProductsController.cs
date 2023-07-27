using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService=productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);    
        }


        [HttpPost("Add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
