using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Ecommerce.DTO;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Implementation;
using System.Security.Permissions;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("List/{search:alpha?}")]
        public async Task<IActionResult> List(string search = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.Correct = true;
                response.Result = await _productService.List(search);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpGet("Catalog/{category:alpha}/{search:alpha?}")]
        public async Task<IActionResult> Catalog(string category, string search = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (category.ToLower() == "EVERYTHING") category = "";
                if (search == "NA") search = "";


                response.Correct = true;
                response.Result = await _productService.Catalog(category, search);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpGet("Get/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _productService.Get(Id);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _productService.Create(model);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Correct = true;
                response.Result = await _productService.Edit(model);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Correct = true;
                response.Result = await _productService.Delete(Id);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }
    }
}
