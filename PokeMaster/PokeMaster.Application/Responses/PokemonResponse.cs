namespace PokeMaster.Application.Responses;

public class PokemonResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Types { get; set; } = new List<string>();
    public List<string> Evolutions { get; set; } = new List<string>();
}
