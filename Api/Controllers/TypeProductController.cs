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
    public class TypeProductController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypeProductDto>>> Get()
        {
            var typeproduct = await _unitOfWork.TypeProducts.GetAllAsync();
            return _mapper.Map<List<TypeProductDto>>(typeproduct);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProductDto>> Get(int id)
        {
            var typeproducts = await _unitOfWork.TypeProducts.GetByIdAsync(id);
            if (typeproducts == null)
            {
                return NotFound();
            }
            return _mapper.Map<TypeProductDto>(typeproducts);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TypeProductDto>> Post(TypeProductDto typeProductDto)
        {
            var typeproduct = _mapper.Map<Typeproduct>(typeProductDto);
            _unitOfWork.TypeProducts.Add(typeproduct);
            await _unitOfWork.SaveAsync();
            if (typeproduct == null)
            {
                return BadRequest();
            }
            typeProductDto.Id = typeproduct.Id;
            return CreatedAtAction(nameof(Post), new {id = typeProductDto.Id}, typeProductDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TypeProductDto>> Put(int id, TypeProductDto typeProductDto)
        {
            if (typeProductDto.Id == 0){
                typeProductDto.Id = id;
            }
            if (typeProductDto.Id != id){
                return BadRequest();
            }
            if (typeProductDto == null){
                return NotFound();
            }
            var typeproducts = _mapper.Map<Typeproduct>(typeProductDto);
            _unitOfWork.TypeProducts.Update(typeproducts);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TypeProductDto>(typeproducts);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeproduct = await _unitOfWork.TypeProducts.GetByIdAsync(id);
            if (typeproduct == null)
            {
                return NotFound();
            }
            _unitOfWork.TypeProducts.Remove(typeproduct);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}