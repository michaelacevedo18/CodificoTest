using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionModels.ComplexObjects;


namespace SalesDatePredictionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _context;
        protected ApiResponse _respuestaDto;
        public ProductsController(IProductRepository context)
        {
            _context = context;
            _respuestaDto = new ApiResponse();
        }

        //Punto 3 Web Api
        ///Listar todos los productos 
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var obj = await _context.GetProducts();

                _respuestaDto.IsSuccess = true;
                _respuestaDto.Result = obj;
                _respuestaDto.QuantityResults = obj.Count();
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en el metodo GetProducts";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }
        }
    }
}
