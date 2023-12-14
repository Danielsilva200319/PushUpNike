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
    public class PhoneController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PhoneController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PhoneDto>>> Get()
        {
            var phone = await _unitOfWork.Phones.GetAllAsync();
            return _mapper.Map<List<PhoneDto>>(phone);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhoneDto>> Get(int id)
        {
            var phones = await _unitOfWork.Phones.GetByIdAsync(id);
            if (phones == null)
            {
                return NotFound();
            }
            return _mapper.Map<PhoneDto>(phones);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PhoneDto>> Post(PhoneDto phoneDto)
        {
            var phone = _mapper.Map<Phone>(phoneDto);
            _unitOfWork.Phones.Add(phone);
            await _unitOfWork.SaveAsync();
            if (phone == null)
            {
                return BadRequest();
            }
            phoneDto.Id = phone.Id;
            return CreatedAtAction(nameof(Post), new {id = phoneDto.Id}, phoneDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PhoneDto>> Put(int id, PhoneDto phoneDto)
        {
            if (phoneDto.Id == 0){
                phoneDto.Id = id;
            }
            if (phoneDto.Id != id){
                return BadRequest();
            }
            if (phoneDto == null){
                return NotFound();
            }
            var phones = _mapper.Map<Phone>(phoneDto);
            _unitOfWork.Phones.Update(phones);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PhoneDto>(phones);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var phone = await _unitOfWork.Phones.GetByIdAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            _unitOfWork.Phones.Remove(phone);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}