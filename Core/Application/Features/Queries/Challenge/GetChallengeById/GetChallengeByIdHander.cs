using Application.Repositories.ChallengeRepository;
using MediatR;

namespace Application.Features.Queries.Challenge.GetChallengeById
{
    public class GetChallengeByIdHander : IRequestHandler<GetChallengeByIdRequest, GetChallengeByIdResponse>
    {
        private readonly IChallengeReadRepository _challengeReadRepository;

        public GetChallengeByIdHander(IChallengeReadRepository challengeReadRepository)
        {
            _challengeReadRepository = challengeReadRepository;
        }

        public async Task<GetChallengeByIdResponse> Handle(GetChallengeByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _challengeReadRepository.GetByIdAsync(request.Id, false);

            if(result == null)
                throw new Exception("Challenge not found"); //todo : create custom exception
            

            return new()
            {
                Title = result.Title,
                Description = result.Description,
                Price = result.Price,
                EventId = result.EventId
            };
        }
    }
}
