using Application.Repositories.ChallengeRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Challenge.GetChallenge
{
    public class GetChallengeByIdQueryHandler : IRequestHandler<GetChallengeByIdQueryRequest, GetChallengeByIdQueryResponse>
    {
        private readonly IChallengeReadRepository _challengeReadRepository;

        public GetChallengeByIdQueryHandler(IChallengeReadRepository challengeReadRepository)
        {
            _challengeReadRepository = challengeReadRepository;
        }

        public async Task<GetChallengeByIdQueryResponse> Handle(GetChallengeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result =  _challengeReadRepository.GetAll(false);

            return new()
            {
                Challenges = result,
                Size = result.Count()
            };
            
        }
    }
}
