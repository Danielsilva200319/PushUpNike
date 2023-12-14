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
    public class EmployeeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            var employee = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<List<EmployeeDto>>(employee);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employees = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            return _mapper.Map<EmployeeDto>(employees);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EmployeeDto>> Post(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.Employees.Add(employee);
            await _unitOfWork.SaveAsync();
            if (employee == null)
            {
                return BadRequest();
            }
            employeeDto.Id = employee.Id;
            return CreatedAtAction(nameof(Post), new {id = employeeDto.Id}, employeeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EmployeeDto>> Put(int id, EmployeeDto employeeDto)
        {
            if (employeeDto.Id == 0){
                employeeDto.Id = id;
            }
            if (employeeDto.Id != id){
                return BadRequest();
            }
            if (employeeDto == null){
                return NotFound();
            }
            var employees = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.Employees.Update(employees);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EmployeeDto>(employees);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _unitOfWork.Employees.Remove(employee);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}