using MediatR;
using PokeMaster.Application.Responses;
using PokeMaster.Infra.Services.Interfaces;

namespace PokeMaster.Application.Queries.Handlers;

public class GetMasterByIdQueryHandler : IRequestHandler<GetMasterByIdQuery, MasterResponse>
{
    public readonly IMasterService _masterService;
    public GetMasterByIdQueryHandler(IMasterService masterService)
    {
        _masterService = masterService;
    }

    public async Task<MasterResponse> Handle(GetMasterByIdQuery request, CancellationToken cancellationToken)
    {
        var master = await _masterService.GetMasterBy(request.Id);
        return new MasterResponse
        {
            Id = master.Id,
            Name = master.Name,
            Age = master.Age,
            CPF = master.CPF,
            CapturedPokemons = master.CapturedPokemons
        };
    }
}
