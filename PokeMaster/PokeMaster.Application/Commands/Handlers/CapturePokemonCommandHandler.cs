using MediatR;
using PokeMaster.Infra.Services.Interfaces;

namespace PokeMaster.Application.Commands.Handlers;

public class CapturePokemonCommandHandler : IRequestHandler<CapturePokemonCommand>
{
    public readonly IMasterService _masterService;
    public CapturePokemonCommandHandler(IMasterService masterService)
    {
        _masterService = masterService;
    }

    public async Task Handle(CapturePokemonCommand command, CancellationToken cancellationToken)
    {
        await _masterService.Capture(command.MasterId, command.PokemonId, cancellationToken);
    }
}
