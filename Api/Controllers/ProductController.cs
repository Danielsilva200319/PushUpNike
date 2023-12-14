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
    public class ProductController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var product = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(product);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var products = await _unitOfWork.Products.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProductDto>(products);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductDto>> Post(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();
            if (product == null)
            {
                return BadRequest();
            }
            productDto.Id = product.Id;
            return CreatedAtAction(nameof(Post), new {id = productDto.Id}, productDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductDto>> Put(int id, ProductDto productDto)
        {
            if (productDto.Id == 0){
                productDto.Id = id;
            }
            if (productDto.Id != id){
                return BadRequest();
            }
            if (productDto == null){
                return NotFound();
            }
            var products = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Update(products);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductDto>(products);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}