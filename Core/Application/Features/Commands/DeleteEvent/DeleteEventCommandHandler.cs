using Application.Repositories.EventRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, DeleteEventCommandResponse>
    {
        private readonly IEventReadRepository _eventReadRepository;
        private readonly IEventWriteRepository _eventWriteRepository;

        public DeleteEventCommandHandler(IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
        }

        public async Task<DeleteEventCommandResponse> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEvent = await _eventReadRepository.GetByIdAsync(request.Id, false);
            if(deletedEvent == null)
            {
                return new()
                {
                    isSuccess = false,
                    Message = "Event not found"
                };
            }

            _ = _eventWriteRepository.Remove(deletedEvent);
            var result = _eventWriteRepository.SaveAsync();

            return new()
            {
                isSuccess = result.Result > 0,
                Message = result.Result > 0 ? "Event deleted successfully" : "Failed to delete event"
            };
        }
    }
}
