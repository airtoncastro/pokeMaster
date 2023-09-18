using MediatR;
using PokeMaster.Application.Responses;

namespace PokeMaster.Application.Queries;

public class GetRandomPokemonByQuantityQuery : IRequest<List<PokemonResponse>>
{
    public int Quantity { get; set; } = 10;
}
