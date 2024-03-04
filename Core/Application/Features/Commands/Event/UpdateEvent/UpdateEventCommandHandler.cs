using Application.Repositories.EventRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, UpdateEventCommandResponse>
    {
        private readonly IEventWriteRepository _eventWriteRepository;

        public UpdateEventCommandHandler(IEventWriteRepository eventWriteRepository)
        {
            _eventWriteRepository = eventWriteRepository;
        }

        public async Task<UpdateEventCommandResponse> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
        {
            _ = _eventWriteRepository.Update(new()
            {
                Id = request.Id,
                Name = request.Name,
                Image = request.Image,
                Location = request.Location,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Description = request.Description,
            });
            var result = await _eventWriteRepository.SaveAsync();

            return new()
            {
                isSuccess = result > 0,
                Message = result > 0 ? "Event updated successfully" : "Failed to update event"
            };


        }
    }
}
