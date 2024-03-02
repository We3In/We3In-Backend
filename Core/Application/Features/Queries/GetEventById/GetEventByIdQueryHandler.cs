﻿using Application.Repositories.EventRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQueryRequest, GetEventByIdQueryResponse>
    {   
        private readonly IEventReadRepository _eventReadRepository;

        public GetEventByIdQueryHandler(IEventReadRepository eventReadRepository)
        {
            _eventReadRepository = eventReadRepository;
        }

        public async Task<GetEventByIdQueryResponse> Handle(GetEventByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _eventReadRepository.GetByIdAsync(request.Id, false); 
            
            return new()
            {
                Name = result.Name,
                Description = result.Description,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
                Location = result.Location,
                Image = result.Image
            };
            

        }
    }
}
