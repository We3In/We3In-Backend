using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Challenge.GetChallengeById
{
    public class GetChallengeByIdResponse
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public long Price { get; set; }

        public Guid EventId { get; set; }
    }
}
