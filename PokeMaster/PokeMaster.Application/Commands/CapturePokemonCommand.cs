using MediatR;

namespace PokeMaster.Application.Commands;

public class CapturePokemonCommand : IRequest
{
    public int MasterId { get; set; }
    public int PokemonId { get; set; }
}
