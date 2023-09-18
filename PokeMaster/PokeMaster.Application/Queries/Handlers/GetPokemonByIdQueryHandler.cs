using MediatR;
using Newtonsoft.Json;
using PokeMaster.Application.Responses;
using PokeMaster.Infra.Services.Interfaces;

namespace PokeMaster.Application.Queries.Handlers;

public class GetPokemonByIdQueryHandler : IRequestHandler<GetPokemonByIdQuery, PokemonResponse>
{
    private readonly IPokemonService _pokemonService;

    public GetPokemonByIdQueryHandler(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<PokemonResponse> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _pokemonService.GetPokemonBy(request.Id, cancellationToken);
        var pokemon = new PokemonResponse
        {
            Id = response.Id,
            Name = response.Name,
            Evolutions = response.Evolutions,
            Types = response.Types.Select(t => t.Type.Name).ToList(),
        };
        return pokemon ?? new PokemonResponse();
    }
}
