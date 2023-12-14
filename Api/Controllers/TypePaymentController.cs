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
    public class TypePaymentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypePaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypePaymentDto>>> Get()
        {
            var typepayment = await _unitOfWork.TypePayments.GetAllAsync();
            return _mapper.Map<List<TypePaymentDto>>(typepayment);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypePaymentDto>> Get(int id)
        {
            var typepayments = await _unitOfWork.TypePayments.GetByIdAsync(id);
            if (typepayments == null)
            {
                return NotFound();
            }
            return _mapper.Map<TypePaymentDto>(typepayments);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TypePaymentDto>> Post(TypePaymentDto typePaymentDto)
        {
            var typepayment = _mapper.Map<Typepayment>(typePaymentDto);
            _unitOfWork.TypePayments.Add(typepayment);
            await _unitOfWork.SaveAsync();
            if (typepayment == null)
            {
                return BadRequest();
            }
            typePaymentDto.Id = typepayment.Id;
            return CreatedAtAction(nameof(Post), new {id = typePaymentDto.Id}, typePaymentDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TypePaymentDto>> Put(int id, TypePaymentDto typePaymentDto)
        {
            if (typePaymentDto.Id == 0){
                typePaymentDto.Id = id;
            }
            if (typePaymentDto.Id != id){
                return BadRequest();
            }
            if (typePaymentDto == null){
                return NotFound();
            }
            var typepayments = _mapper.Map<Typepayment>(typePaymentDto);
            _unitOfWork.TypePayments.Update(typepayments);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TypePaymentDto>(typepayments);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typepayment = await _unitOfWork.TypePayments.GetByIdAsync(id);
            if (typepayment == null)
            {
                return NotFound();
            }
            _unitOfWork.TypePayments.Remove(typepayment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}