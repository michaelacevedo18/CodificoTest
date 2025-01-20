using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionModels.ComplexObjects;


namespace SalesDatePredictionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _context;
        protected ApiResponse _respuestaDto;
        public CustomerController(ICustomerRepository context)
        {
            _context = context;
            _respuestaDto = new ApiResponse();
        }
      

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.GetCustomersAsync();

            return Ok(customers);
        }


        
        [HttpGet("GetLastNextOrder")]
        public async Task<IActionResult> GetLastNextOrder(int idCustomer)
        {
            var customers = await _context.GetLastNextOrder(idCustomer);

            return Ok(customers);
        }


        //Punto 3 Web Api
        ///Listar clientes con fecha de ultima orden y fecha de posible orden 
        [HttpGet("GetTotalLastNextOrder")]
        public async Task<IActionResult> GetTotalLastNextOrder(string? Name)
        {
            try
            {
                var obj = await _context.GettotalLastNextOrder(Name);

                _respuestaDto.IsSuccess = true;
                _respuestaDto.Result = obj;
                _respuestaDto.QuantityResults = obj.Count();
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en el metodo GetTotalLastNextOrder";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }            
        }
    }
}
