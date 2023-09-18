using MediatR;
using PokeMaster.Domain.Entities;
using PokeMaster.Infra.Services.Interfaces;

namespace PokeMaster.Application.Commands.Handlers;

public class CreateMasterCommandHandler : IRequestHandler<CreateMasterCommand>
{
    private readonly IMasterService _masterService;

    public CreateMasterCommandHandler(IMasterService masterService)
    {
        _masterService = masterService;
    }

    public async Task Handle(CreateMasterCommand command, CancellationToken cancellationToken)
    {
        await _masterService.Create(new Master { Age = command.Age, CPF = command.CPF, Name = command.Name });
    }
}
