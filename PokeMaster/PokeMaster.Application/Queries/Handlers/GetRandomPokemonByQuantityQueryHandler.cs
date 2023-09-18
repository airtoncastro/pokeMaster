using MediatR;
using PokeMaster.Application.Responses;
using PokeMaster.Infra.Services.Interfaces;

namespace PokeMaster.Application.Queries.Handlers;

public class GetRandomPokemonByQuantityQueryHandler : IRequestHandler<GetRandomPokemonByQuantityQuery, List<PokemonResponse>>
{
    private readonly IPokemonService _pokemonService;
    private readonly IMediator _mediator;

    public GetRandomPokemonByQuantityQueryHandler(IPokemonService pokemonService, IMediator mediator)
    {
        _pokemonService = pokemonService;
        _mediator = mediator;
    }

    public async Task<List<PokemonResponse>> Handle(GetRandomPokemonByQuantityQuery request, CancellationToken cancellationToken)
    {
        var list = new List<PokemonResponse>();
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            var randomId = random.Next(1008);
            var result = await _mediator.Send(new GetPokemonByIdQuery { Id = randomId }, cancellationToken);
            list.Add(result);
        }
        return list;
    }
}
