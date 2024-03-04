using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models;
using Shop.Core;
using Shop.Core.DTOs;
using Shop.Core.Entities;
using Shop.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        //private readonly Mapping _mapping;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;   
           
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list=await _orderService.GetAllOrdersAsync();
            var listDto = _mapper.Map<IEnumerable<OrderDTO>>(list);
         
            return Ok(listDto);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.GetOrderByID(id);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return Ok(orderDTO);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderPostModel order)
        {
            var orderToAdd = new Order{ Id = order.Id, SumOrder = order.SumOrder };
            var newOrder =await _orderService.AddOrderAsync(orderToAdd);
            return Ok(newOrder);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrderPostModel order)
        {
            var orderToAdd = new Order { Id = order.Id, SumOrder = order.SumOrder };
            var newOrder = _orderService.UpdateOrder(id,orderToAdd);
            return Ok(newOrder);
          
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
