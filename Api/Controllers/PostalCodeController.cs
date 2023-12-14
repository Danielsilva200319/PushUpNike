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
    public class PostalCodeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostalCodeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PostalCodeDto>>> Get()
        {
            var postalcode = await _unitOfWork.PostalCodes.GetAllAsync();
            return _mapper.Map<List<PostalCodeDto>>(postalcode);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostalCodeDto>> Get(int id)
        {
            var postalcodes = await _unitOfWork.PostalCodes.GetByIdAsync(id);
            if (postalcodes == null)
            {
                return NotFound();
            }
            return _mapper.Map<PostalCodeDto>(postalcodes);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PostalCodeDto>> Post(PostalCodeDto postalCodeDto)
        {
            var postalcode = _mapper.Map<Postalcode>(postalCodeDto);
            _unitOfWork.PostalCodes.Add(postalcode);
            await _unitOfWork.SaveAsync();
            if (postalcode == null)
            {
                return BadRequest();
            }
            postalCodeDto.Id = postalcode.Id;
            return CreatedAtAction(nameof(Post), new {id = postalCodeDto.Id}, postalCodeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PostalCodeDto>> Put(int id, PostalCodeDto postalCodeDto)
        {
            if (postalCodeDto.Id == 0){
                postalCodeDto.Id = id;
            }
            if (postalCodeDto.Id != id){
                return BadRequest();
            }
            if (postalCodeDto == null){
                return NotFound();
            }
            var postalcodes = _mapper.Map<Postalcode>(postalCodeDto);
            _unitOfWork.PostalCodes.Update(postalcodes);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PostalCodeDto>(postalcodes);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var postalcode = await _unitOfWork.PostalCodes.GetByIdAsync(id);
            if (postalcode == null)
            {
                return NotFound();
            }
            _unitOfWork.PostalCodes.Remove(postalcode);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}