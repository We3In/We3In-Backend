using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Event.GetEventById
{
    public class GetEventByIdQueryRequest : IRequest<GetEventByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
