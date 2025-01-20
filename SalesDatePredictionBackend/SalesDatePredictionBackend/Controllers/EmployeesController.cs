using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionDataAccess;
using SalesDatePredictionModels.ComplexObjects;



namespace SalesDatePredictionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _context;
        protected ApiResponse _respuestaDto;
        public EmployeesController(IEmployeeRepository context)
        {
            _context = context;
            _respuestaDto = new ApiResponse();
        }

        //Punto 3 Web Api
        ///Listar todos los empleados 

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var obj = await _context.GetEmployees();

                _respuestaDto.IsSuccess = true;
                _respuestaDto.Result = obj;
                _respuestaDto.QuantityResults = obj.Count();
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en el metodo GetEmployees";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }
          
        }

       
    }
}
