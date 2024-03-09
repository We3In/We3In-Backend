using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Challenge.GetChallenge
{
    public class GetChallengeByIdQueryResponse
    {
        public object Challenges { get; set; }
        public int Size { get; set; }
    }
}
