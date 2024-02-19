using Application.Repositories.EventRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventReadRepository _eventReadRepository;
        private readonly IEventWriteRepository _eventWriteRepository;

        public EventController(IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var events = _eventReadRepository.GetAll();
            return Ok(events);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync(String id)
        {
            return Ok(await _eventReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Event @event){
            _ = await _eventWriteRepository.AddAsync(@event);
            var result = _eventWriteRepository.SaveAsync();
            
            return result.Result > 0 ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("range")]
        public async Task<IActionResult> PostRangeAsync(List<Event> @events)
        {
            _ = await _eventWriteRepository.AddRangeAsync(@events);
            var result = _eventWriteRepository.SaveAsync();

            return result.Result > 0 ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult PutAsync(Event @event)
        {
            _ = _eventWriteRepository.Update(@event);
            var result = _eventWriteRepository.SaveAsync();

            return result.Result > 0 ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(String id)
        {
            var deletedEvent = await _eventReadRepository.GetByIdAsync(id, false);
            if(deletedEvent == null)
                return NotFound();

            _ = _eventWriteRepository.Remove(deletedEvent);
            var result = _eventWriteRepository.SaveAsync();

            return result.Result > 0 ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
