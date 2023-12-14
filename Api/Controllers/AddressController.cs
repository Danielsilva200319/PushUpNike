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
    public class AddressController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
        {
            var address = await _unitOfWork.Addresses.GetAllAsync();
            return _mapper.Map<List<AddressDto>>(address);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDto>> Get(int id)
        {
            var addresses = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (addresses == null)
            {
                return NotFound();
            }
            return _mapper.Map<AddressDto>(addresses);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AddressDto>> Post(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _unitOfWork.Addresses.Add(address);
            await _unitOfWork.SaveAsync();
            if (address == null)
            {
                return BadRequest();
            }
            addressDto.Id = address.Id;
            return CreatedAtAction(nameof(Post), new {id = addressDto.Id}, addressDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AddressDto>> Put(int id, AddressDto addressDto)
        {
            if (addressDto.Id == 0){
                addressDto.Id = id;
            }
            if (addressDto.Id != id){
                return BadRequest();
            }
            if (addressDto == null){
                return NotFound();
            }
            var addresses = _mapper.Map<Address>(addressDto);
            _unitOfWork.Addresses.Update(addresses);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AddressDto>(addresses);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            _unitOfWork.Addresses.Remove(address);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}