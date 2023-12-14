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
    public class TypeClientController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypeClientDto>>> Get()
        {
            var typeclient = await _unitOfWork.TypeClients.GetAllAsync();
            return _mapper.Map<List<TypeClientDto>>(typeclient);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClientDto>> Get(int id)
        {
            var typeclients = await _unitOfWork.TypeClients.GetByIdAsync(id);
            if (typeclients == null)
            {
                return NotFound();
            }
            return _mapper.Map<TypeClientDto>(typeclients);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TypeClientDto>> Post(TypeClientDto typeClientDto)
        {
            var typeclient = _mapper.Map<Typeclient>(typeClientDto);
            _unitOfWork.TypeClients.Add(typeclient);
            await _unitOfWork.SaveAsync();
            if (typeclient == null)
            {
                return BadRequest();
            }
            typeClientDto.Id = typeclient.Id;
            return CreatedAtAction(nameof(Post), new {id = typeClientDto.Id}, typeClientDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TypeClientDto>> Put(int id, TypeClientDto typeClientDto)
        {
            if (typeClientDto.Id == 0){
                typeClientDto.Id = id;
            }
            if (typeClientDto.Id != id){
                return BadRequest();
            }
            if (typeClientDto == null){
                return NotFound();
            }
            var typeclients = _mapper.Map<Typeclient>(typeClientDto);
            _unitOfWork.TypeClients.Update(typeclients);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TypeClientDto>(typeclients);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeclient = await _unitOfWork.TypeClients.GetByIdAsync(id);
            if (typeclient == null)
            {
                return NotFound();
            }
            _unitOfWork.TypeClients.Remove(typeclient);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}