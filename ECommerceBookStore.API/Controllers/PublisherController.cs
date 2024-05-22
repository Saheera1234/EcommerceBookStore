﻿using ECommerceBookStore.Application.Command._Publisher;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ApiController
    {
        private readonly IGetPublisherQuery getPublisherQuery;

        public PublisherController(IGetPublisherQuery getPublisherQuery)
        {
            this.getPublisherQuery = getPublisherQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var publisher = getPublisherQuery.GetAllPublishers();
            return Ok(publisher);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var publisher = getPublisherQuery.GetPublisherById(id);
            return Ok(publisher);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PublisherDto publisherDto)
        {
            var command = new PublisherCommand(Operation.Create, publisherDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PublisherDto publisherDto)
        {
            if (id == publisherDto.Id)
            {
                var command = new PublisherCommand(Operation.Update, publisherDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var publisher = new PublisherDto { Id = id };
            var command = new PublisherCommand(Operation.Delete, publisher);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
