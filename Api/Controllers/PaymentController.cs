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
    public class PaymentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> Get()
        {
            var payment = await _unitOfWork.Payments.GetAllAsync();
            return _mapper.Map<List<PaymentDto>>(payment);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDto>> Get(int id)
        {
            var payments = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            return _mapper.Map<PaymentDto>(payments);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PaymentDto>> Post(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            _unitOfWork.Payments.Add(payment);
            await _unitOfWork.SaveAsync();
            if (payment == null)
            {
                return BadRequest();
            }
            paymentDto.Id = payment.Id;
            return CreatedAtAction(nameof(Post), new {id = paymentDto.Id}, paymentDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaymentDto>> Put(int id, PaymentDto paymentDto)
        {
            if (paymentDto.Id == 0){
                paymentDto.Id = id;
            }
            if (paymentDto.Id != id){
                return BadRequest();
            }
            if (paymentDto == null){
                return NotFound();
            }
            var payments = _mapper.Map<Payment>(paymentDto);
            _unitOfWork.Payments.Update(payments);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PaymentDto>(payments);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            _unitOfWork.Payments.Remove(payment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}