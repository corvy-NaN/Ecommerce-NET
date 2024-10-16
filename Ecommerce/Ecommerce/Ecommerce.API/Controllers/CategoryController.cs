using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Implementation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("List/{search:alpha?}")]
        public async Task<IActionResult> List(string search = "NA")
        {
            var response = new ResponseDTO<List<CategoryDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.Correct = true;
                response.Result = await _categoryService.List(search);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpGet("Get/{search:alpha?}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _categoryService.Get(Id);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpPost("Create/{search:alpha?}")]
        public async Task<IActionResult> Create([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _categoryService.Create(model);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPut("Edit/{search:alpha?}")]
        public async Task<IActionResult> Edit([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Correct = true;
                response.Result = await _categoryService.Edit(model);

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
                response.Result = await _categoryService.Delete(Id);

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
