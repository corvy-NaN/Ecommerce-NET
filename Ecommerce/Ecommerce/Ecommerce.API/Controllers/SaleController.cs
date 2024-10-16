using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Implementation;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        public readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SaleDTO model)
        {
            var response = new ResponseDTO<SaleDTO>();

            try
            {
                response.Correct = true;
                response.Result = await _saleService.Register(model);

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
