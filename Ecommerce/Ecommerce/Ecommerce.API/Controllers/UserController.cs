using Microsoft.AspNetCore.Mvc;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;


namespace Ecommerce.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("List/{rol:alpha}/{search:alpha?}")]
        public async Task<IActionResult> List(string rol, string search = "NA")
        {
            var response = new ResponseDTO<List<UserDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.Correct = true;
                response.Result = await _userService.List(rol, search);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }



        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _userService.Get(Id);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _userService.Create(model);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);

        }


        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<SessionDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _userService.Authorization(model);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }



        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Correct = true;
                response.Result = await _userService.Edit(model);

            }
            catch (Exception ex)
            {
                response.Correct = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Correct = true;
                response.Result = await _userService.Delete(Id);

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
