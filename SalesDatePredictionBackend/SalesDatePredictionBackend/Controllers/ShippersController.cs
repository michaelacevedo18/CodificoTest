using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionModels.ComplexObjects;


namespace SalesDatePredictionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperRepository _context;
        protected ApiResponse _respuestaDto;
        public ShippersController(IShipperRepository context)
        {
            _context = context;
            _respuestaDto = new ApiResponse();
        }


        //Punto 3 Web Api
        ///Listar todos lso transportistas 
        [HttpGet]
        public async Task<IActionResult> GetShippers()
        {
            try
            {
                var obj = await _context.GetShippers();

                _respuestaDto.IsSuccess = true;
                _respuestaDto.Result = obj;
                _respuestaDto.QuantityResults = obj.Count();
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en el metodo GetShippers";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }           
        }
    }
}
