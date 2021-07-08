using HansEgAPI.Dtos.OrderDtos;
using HansEgAPI.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HansEgAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IAsyncOrderService _service;

        public OrdersController(IAsyncOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var ordersReadDtoFromService = await _service.GetOrdersAsync();

            return Ok(ordersReadDtoFromService);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderByIdAsync(int orderId)
        {
            if (orderId == 0)
                return BadRequest();

            var orderReadDtoFromService = await _service.GetOrderByIdAsync(orderId);

            if (orderReadDtoFromService == null)
                return StatusCode((int)OrderReadDto.GetNotFoundErrorModel.StatusCode, OrderReadDto.GetNotFoundErrorModel);

            return Ok(orderReadDtoFromService);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetRegionOrdersAsync(int regionId)
        {
            if (regionId == 0)
                return BadRequest();

            var ordersReadDtoFromService = await _service.GetRegionOrdersAsync(regionId);

            if (ordersReadDtoFromService.Count == 0)
                return NotFound();

            return Ok(ordersReadDtoFromService);
        }

        //[HttpPost("{orderId}")]
        //public async Task<IActionResult> GetOrderByIdAsync(int orderId)
        //{
        //    if (orderId == 0)
        //        return BadRequest();

        //    var orderReadDtoFromService = await _service.GetOrderByIdAsync(orderId);

        //    if (orderReadDtoFromService == null)
        //        return NotFound();

        //    return Ok(orderReadDtoFromService);
        //}

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync([FromBody] OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
                return BadRequest();

            await _service.PostOrderAsync(orderCreateDto);

            return StatusCode((int)HttpStatusCode.Created, orderCreateDto);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrderAsync(int orderId)
        {
            if (orderId == 0)
                return BadRequest();

            var orderReadDtoFromService = await _service.GetOrderByIdAsync(orderId);

            if (orderReadDtoFromService == null)
                return StatusCode((int)OrderReadDto.GetNotFoundErrorModel.StatusCode, OrderReadDto.GetNotFoundErrorModel);

            await _service.DeleteOrderAsync(orderId);

            return NoContent();
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrderAsync(int orderId, [FromBody] OrderUpdateDto orderUpdateDto)
        {
            if (orderId == 0 || orderUpdateDto == null)
                return BadRequest();

            var orderReadDtoFromService = await _service.GetOrderByIdAsync(orderId);

            if (orderReadDtoFromService == null)
                return StatusCode((int)OrderReadDto.GetNotFoundErrorModel.StatusCode, OrderReadDto.GetNotFoundErrorModel);

            await _service.UpdateOrderAsync(orderReadDtoFromService, orderUpdateDto);

            return StatusCode((int)HttpStatusCode.OK, orderUpdateDto);
        }

        // Change Order Status
        //[HttpPut("{orderId}")]
        //[Route("[action]")]
        //public async Task<IActionResult> ChangeOrderStauts(int orderId, int orderStatusNumber)
        //{
        //    if (orderId == 0)
        //        return BadRequest();

        //    var orderReadDtoFromService = await _service.GetOrderByIdAsync(orderId);

        //    if (orderReadDtoFromService == null)
        //        return StatusCode((int)OrderReadDto.GetNotFoundErrorModel.StatusCode, OrderReadDto.GetNotFoundErrorModel);

        //    var orderStatus = OrderStatus

        //    //await _service.UpdateOrderAsync(orderReadDtoFromService, orderUpdateDto);

        //    return StatusCode((int)HttpStatusCode.OK, orderUpdateDto);
        //}

    }
}
