using Application.Features.Commands.Event.CreateEvent;
using Application.Features.Commands.Event.DeleteEvent;
using Application.Features.Commands.Event.UpdateEvent;
using Application.Features.Queries.Event.GetEventById;
using Application.Features.Queries.Event.GetEventProduct;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllEventQueryRequest getAllProductQueryRequest)
        {
          GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("by-id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(GetEventByIdQueryRequest getEventByIdQueryRequest)
        {
            GetEventByIdQueryResponse response = await _mediator.Send(getEventByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateEventCommandRequest createEventCommandRequest){
            var userId = User.FindFirst(ClaimTypes.Name).Value;

            if (userId == null)
                return StatusCode(StatusCodes.Status401Unauthorized, "Unauthorized");

            createEventCommandRequest.CreatorUserId = userId;
            CreateEventCommandResponse response = await _mediator.Send(createEventCommandRequest);
            return response.isSuccess ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateEventCommandRequest updateEventCommandRequest)
        {
            var userId = User.FindFirst(ClaimTypes.Name).Value;


            if (userId == null)
                return StatusCode(StatusCodes.Status401Unauthorized, "Unauthorized");

            UpdateEventCommandResponse response = await _mediator.Send(updateEventCommandRequest);

            return response.isSuccess ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteEventCommandRequest deleteEventCommandRequest)
        {
            DeleteEventCommandResponse response = await _mediator.Send(deleteEventCommandRequest);

            return response.isSuccess ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
