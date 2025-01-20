using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionModels;
using SalesDatePredictionModels.ComplexObjects;
using SalesDatePredictionModels.EntitiesObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesDatePredictionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository context;
        protected ApiResponse _respuestaDto;
        public OrdersController(IOrderRepository _context)
        {
            context = _context;
            _respuestaDto = new ApiResponse();
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var obj = await context.GetOrders();

                _respuestaDto.IsSuccess = true;
                _respuestaDto.Result = obj;
                _respuestaDto.QuantityResults= obj.Count();
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en el metodo GetOrders";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }
        }


        [HttpGet("GetOrdersById")]
        public async Task<List<Order>> GetOrderById(int id)
        {
            return await context.GetOrdersByIdAsync(id);
        }

        //Punto 3 Web Api
        ///Listar ordenes por cliente 
        [HttpGet("GetOrdersByCustomerId")] 
        public async Task<ActionResult> GetOrdersByCustomerId(int customerId)
        {
            try
            {
                var obj = await context.GetOrdersByCustomerIdAsync(customerId);

                _respuestaDto.IsSuccess = true;
                _respuestaDto.Result = obj;
                _respuestaDto.QuantityResults = obj.Count();
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en el metodo GetOrdersByCustomerId";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }            
        }
                
        [HttpGet("GetOrdersByCustomerName")]
        public async Task<List<Order>> GetOrdersByCustomerName(string name)
        {
            return await context.GetOrdersByNameAsync(name);
        }


        //Punto 3 Web Api
        ///Crear una orden nueva con un producto 
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                if (orderDto == null || orderDto.OrderDetails == null || !orderDto.OrderDetails.Any())
                {
                    _respuestaDto.IsSuccess = false;
                    _respuestaDto.DisplayMessage = "Invalid order data.";
                    return BadRequest(_respuestaDto);
                }

                await context.CreateOrderAsync(orderDto);

                _respuestaDto.IsSuccess = true;
                _respuestaDto.DisplayMessage = "Orden guardada con éxito";
                return Ok(_respuestaDto);
            }
            catch (Exception ex)
            {
                _respuestaDto.IsSuccess = false;
                _respuestaDto.DisplayMessage = "Ha ocurrido un error en la inserción de los datos.";
                _respuestaDto.ErrorMessages = ex;
                return BadRequest(_respuestaDto);
            }
        }

    }
}
