using MediatR;

namespace PokeMaster.Application.Commands;

public class CreateMasterCommand: IRequest
{
    public string Name { get; set; } = string.Empty;
    public short Age { get; set; }
    public string CPF { get; set; } = string.Empty;
}
