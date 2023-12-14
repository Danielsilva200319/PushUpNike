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
    public class ShipmentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShipmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ShipmentDto>>> Get()
        {
            var shipment = await _unitOfWork.Shipments.GetAllAsync();
            return _mapper.Map<List<ShipmentDto>>(shipment);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShipmentDto>> Get(int id)
        {
            var shipments = await _unitOfWork.Shipments.GetByIdAsync(id);
            if (shipments == null)
            {
                return NotFound();
            }
            return _mapper.Map<ShipmentDto>(shipments);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ShipmentDto>> Post(ShipmentDto shipmentDto)
        {
            var shipment = _mapper.Map<Shipment>(shipmentDto);
            _unitOfWork.Shipments.Add(shipment);
            await _unitOfWork.SaveAsync();
            if (shipment == null)
            {
                return BadRequest();
            }
            shipmentDto.Id = shipment.Id;
            return CreatedAtAction(nameof(Post), new {id = shipmentDto.Id}, shipmentDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ShipmentDto>> Put(int id, ShipmentDto shipmentDto)
        {
            if (shipmentDto.Id == 0){
                shipmentDto.Id = id;
            }
            if (shipmentDto.Id != id){
                return BadRequest();
            }
            if (shipmentDto == null){
                return NotFound();
            }
            var shipments = _mapper.Map<Shipment>(shipmentDto);
            _unitOfWork.Shipments.Update(shipments);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ShipmentDto>(shipments);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var shipment = await _unitOfWork.Shipments.GetByIdAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            _unitOfWork.Shipments.Remove(shipment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}