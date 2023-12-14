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
    public class TypeShipmentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeShipmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypeShipmentDto>>> Get()
        {
            var typeshipment = await _unitOfWork.TypeShipments.GetAllAsync();
            return _mapper.Map<List<TypeShipmentDto>>(typeshipment);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeShipmentDto>> Get(int id)
        {
            var typeshipments = await _unitOfWork.TypeShipments.GetByIdAsync(id);
            if (typeshipments == null)
            {
                return NotFound();
            }
            return _mapper.Map<TypeShipmentDto>(typeshipments);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TypeShipmentDto>> Post(TypeShipmentDto typeShipmentDto)
        {
            var typeshipment = _mapper.Map<Typeshipment>(typeShipmentDto);
            _unitOfWork.TypeShipments.Add(typeshipment);
            await _unitOfWork.SaveAsync();
            if (typeshipment == null)
            {
                return BadRequest();
            }
            typeShipmentDto.Id = typeshipment.Id;
            return CreatedAtAction(nameof(Post), new {id = typeShipmentDto.Id}, typeShipmentDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TypeShipmentDto>> Put(int id, TypeShipmentDto typeShipmentDto)
        {
            if (typeShipmentDto.Id == 0){
                typeShipmentDto.Id = id;
            }
            if (typeShipmentDto.Id != id){
                return BadRequest();
            }
            if (typeShipmentDto == null){
                return NotFound();
            }
            var typeshipments = _mapper.Map<Typeshipment>(typeShipmentDto);
            _unitOfWork.TypeShipments.Update(typeshipments);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TypeShipmentDto>(typeshipments);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeshipment = await _unitOfWork.TypeShipments.GetByIdAsync(id);
            if (typeshipment == null)
            {
                return NotFound();
            }
            _unitOfWork.TypeShipments.Remove(typeshipment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}