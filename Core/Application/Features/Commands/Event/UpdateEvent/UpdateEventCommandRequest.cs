﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandRequest : IRequest<UpdateEventCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string CreatorUserId { get; set; }
    }
}
