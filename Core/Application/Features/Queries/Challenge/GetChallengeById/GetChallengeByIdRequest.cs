﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Challenge.GetChallengeById
{
    public class GetChallengeByIdRequest : IRequest<GetChallengeByIdResponse>
    {
        public string Id { get; set; }
    }
}
