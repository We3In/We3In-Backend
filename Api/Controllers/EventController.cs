﻿using Application.Features.Commands.Event.CreateEvent;
using Application.Features.Commands.Event.DeleteEvent;
using Application.Features.Commands.Event.UpdateEvent;
using Application.Features.Queries.Event.GetEventById;
using Application.Features.Queries.Event.GetEventProduct;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllEventQueryRequest getAllProductQueryRequest)
        {
          GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync(GetEventByIdQueryRequest getEventByIdQueryRequest)
        {
            GetEventByIdQueryResponse response = await _mediator.Send(getEventByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PostAsync(CreateEventCommandRequest createEventCommandRequest){
            CreateEventCommandResponse response = await _mediator.Send(createEventCommandRequest);
            return response.isSuccess ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutAsync(UpdateEventCommandRequest updateEventCommandRequest)
        {
            UpdateEventCommandResponse response = await _mediator.Send(updateEventCommandRequest);

            return response.isSuccess ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes ="Admin")]
        public async Task<IActionResult> DeleteAsync(DeleteEventCommandRequest deleteEventCommandRequest)
        {
            DeleteEventCommandResponse response = await _mediator.Send(deleteEventCommandRequest);

            return response.isSuccess ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
