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
    public class ClientController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
        {
            var client = await _unitOfWork.Clients.GetAllAsync();
            return _mapper.Map<List<ClientDto>>(client);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDto>> Get(int id)
        {
            var clients = await _unitOfWork.Clients.GetByIdAsync(id);
            if (clients == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClientDto>(clients);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ClientDto>> Post(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            _unitOfWork.Clients.Add(client);
            await _unitOfWork.SaveAsync();
            if (client == null)
            {
                return BadRequest();
            }
            clientDto.Id = client.Id;
            return CreatedAtAction(nameof(Post), new {id = clientDto.Id}, clientDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ClientDto>> Put(int id, ClientDto clientDto)
        {
            if (clientDto.Id == 0){
                clientDto.Id = id;
            }
            if (clientDto.Id != id){
                return BadRequest();
            }
            if (clientDto == null){
                return NotFound();
            }
            var clients = _mapper.Map<Client>(clientDto);
            _unitOfWork.Clients.Update(clients);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ClientDto>(clients);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _unitOfWork.Clients.Remove(client);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}