using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var order = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(order);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var orders = await _unitOfWork.Orders.GetByIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return _mapper.Map<OrderDto>(orders);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<OrderDto>> Post(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _unitOfWork.Orders.Add(order);
            await _unitOfWork.SaveAsync();
            if (order == null)
            {
                return BadRequest();
            }
            orderDto.Id = order.Id;
            return CreatedAtAction(nameof(Post), new {id = orderDto.Id}, orderDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<OrderDto>> Put(int id, OrderDto orderDto)
        {
            if (orderDto.Id == 0){
                orderDto.Id = id;
            }
            if (orderDto.Id != id){
                return BadRequest();
            }
            if (orderDto == null){
                return NotFound();
            }
            var orders = _mapper.Map<Order>(orderDto);
            _unitOfWork.Orders.Update(orders);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<OrderDto>(orders);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}