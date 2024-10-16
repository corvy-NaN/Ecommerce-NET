using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public readonly IDashBoardService _dashboardService;

        public DashboardController(IDashBoardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("Summary")]
        public IActionResult Summary()
        {
            var response = new ResponseDTO<DashBoardDTO>();

            try
            {
                response.Correct = true;
                response.Result = _dashboardService.Summary();

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
