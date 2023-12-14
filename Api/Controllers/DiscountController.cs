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
    public class DiscountController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiscountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> Get()
        {
            var discount = await _unitOfWork.Discounts.GetAllAsync();
            return _mapper.Map<List<DiscountDto>>(discount);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountDto>> Get(int id)
        {
            var discounts = await _unitOfWork.Discounts.GetByIdAsync(id);
            if (discounts == null)
            {
                return NotFound();
            }
            return _mapper.Map<DiscountDto>(discounts);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DiscountDto>> Post(DiscountDto discountDto)
        {
            var discount = _mapper.Map<Discount>(discountDto);
            _unitOfWork.Discounts.Add(discount);
            await _unitOfWork.SaveAsync();
            if (discount == null)
            {
                return BadRequest();
            }
            discountDto.Id = discount.Id;
            return CreatedAtAction(nameof(Post), new {id = discountDto.Id}, discountDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DiscountDto>> Put(int id, DiscountDto discountDto)
        {
            if (discountDto.Id == 0){
                discountDto.Id = id;
            }
            if (discountDto.Id != id){
                return BadRequest();
            }
            if (discountDto == null){
                return NotFound();
            }
            var discounts = _mapper.Map<Discount>(discountDto);
            _unitOfWork.Discounts.Update(discounts);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DiscountDto>(discounts);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var discount = await _unitOfWork.Discounts.GetByIdAsync(id);
            if (discount == null)
            {
                return NotFound();
            }
            _unitOfWork.Discounts.Remove(discount);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}