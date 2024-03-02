using Application.Repositories.EventRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, CreateEventCommandResponse>
    {
        private readonly IEventWriteRepository _eventWriteRepository;

        public CreateEventCommandHandler(IEventWriteRepository eventWriteRepository)
        {
            _eventWriteRepository = eventWriteRepository;
        }

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            _ = await _eventWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Image = request.Image,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
            });
            var result = _eventWriteRepository.SaveAsync();

            return new()
            {
                isSuccess = result.Result > 0,
                Message = result.Result > 0 ? "Event created successfully" : "Failed to create event"
            };
        }
    }
}
