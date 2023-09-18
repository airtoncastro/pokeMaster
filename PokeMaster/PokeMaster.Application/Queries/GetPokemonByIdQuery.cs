using MediatR;
using PokeMaster.Application.Responses;

namespace PokeMaster.Application.Queries;

public class GetPokemonByIdQuery : IRequest<PokemonResponse>
{
    public int Id { get; set; }
}
