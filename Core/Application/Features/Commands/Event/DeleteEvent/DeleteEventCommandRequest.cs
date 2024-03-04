using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Event.DeleteEvent
{
    public class DeleteEventCommandRequest : IRequest<DeleteEventCommandResponse>
    {
        public string Id { get; set; }
    }
}
