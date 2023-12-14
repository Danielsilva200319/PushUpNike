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
    public class TypeOrderController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeOrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypeOrderDto>>> Get()
        {
            var typeorder = await _unitOfWork.TypeOrders.GetAllAsync();
            return _mapper.Map<List<TypeOrderDto>>(typeorder);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeOrderDto>> Get(int id)
        {
            var typeorders = await _unitOfWork.TypeOrders.GetByIdAsync(id);
            if (typeorders == null)
            {
                return NotFound();
            }
            return _mapper.Map<TypeOrderDto>(typeorders);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TypeOrderDto>> Post(TypeOrderDto typeOrderDto)
        {
            var typeorder = _mapper.Map<Typeorder>(typeOrderDto);
            _unitOfWork.TypeOrders.Add(typeorder);
            await _unitOfWork.SaveAsync();
            if (typeorder == null)
            {
                return BadRequest();
            }
            typeOrderDto.Id = typeorder.Id;
            return CreatedAtAction(nameof(Post), new {id = typeOrderDto.Id}, typeOrderDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TypeOrderDto>> Put(int id, TypeOrderDto typeOrderDto)
        {
            if (typeOrderDto.Id == 0){
                typeOrderDto.Id = id;
            }
            if (typeOrderDto.Id != id){
                return BadRequest();
            }
            if (typeOrderDto == null){
                return NotFound();
            }
            var typeorders = _mapper.Map<Typeorder>(typeOrderDto);
            _unitOfWork.TypeOrders.Update(typeorders);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TypeOrderDto>(typeorders);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeorder = await _unitOfWork.TypeOrders.GetByIdAsync(id);
            if (typeorder == null)
            {
                return NotFound();
            }
            _unitOfWork.TypeOrders.Remove(typeorder);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}