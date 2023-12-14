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
    public class CategoryController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var category = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(category);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var categories = await _unitOfWork.Categories.GetByIdAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoryDto>(categories);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CategoryDto>> Post(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _unitOfWork.Categories.Add(category);
            await _unitOfWork.SaveAsync();
            if (category == null)
            {
                return BadRequest();
            }
            categoryDto.Id = category.Id;
            return CreatedAtAction(nameof(Post), new {id = categoryDto.Id}, categoryDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CategoryDto>> Put(int id, CategoryDto categoryDto)
        {
            if (categoryDto.Id == 0){
                categoryDto.Id = id;
            }
            if (categoryDto.Id != id){
                return BadRequest();
            }
            if (categoryDto == null){
                return NotFound();
            }
            var categories = _mapper.Map<Category>(categoryDto);
            _unitOfWork.Categories.Update(categories);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CategoryDto>(categories);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}