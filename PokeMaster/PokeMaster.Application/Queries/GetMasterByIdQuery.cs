using MediatR;
using PokeMaster.Application.Responses;

namespace PokeMaster.Application.Queries;

public class GetMasterByIdQuery : IRequest<MasterResponse>
{
    public int Id { get; set; }
}
