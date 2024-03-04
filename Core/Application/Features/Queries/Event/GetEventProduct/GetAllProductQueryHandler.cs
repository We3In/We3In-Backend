using Application.Repositories.EventRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Event.GetEventProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IEventReadRepository _eventReadRepository;

        public GetAllProductQueryHandler(IEventReadRepository eventReadRepository)
        {
            _eventReadRepository = eventReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _eventReadRepository.GetAll(false).Count();
            var events = _eventReadRepository.GetAll(false)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToList();

            return new()
            {
                TotalCount = totalCount,
                Events = events
            };
        }
    }
}
