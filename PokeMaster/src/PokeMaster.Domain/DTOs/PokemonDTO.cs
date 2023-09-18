namespace PokeMaster.Domain.DTOs;

public class PokemonDTO
{
public int Id { get; set; }
public string Name { get; set; } = string.Empty;
public List<TypeSlot> Types { get; set; } = new List<TypeSlot>();
public List<string> Evolutions { get; set; } = new List<string>();

public void LoadEvolutions(EvolutionChainDTO evolutionChain)
{
    AddSpeciesNames(evolutionChain.Chain, Evolutions);
}
private void AddSpeciesNames(Chain? chain, List<string> names)
{
    if (chain == null || chain.Species == null || chain.Species.Name == null) return;

    names.Add(chain.Species.Name);

    if (chain.EvolvesTo != null)
        foreach (var subChain in chain.EvolvesTo)
            AddSpeciesNames(subChain, names);
}
}

public class TypeSlot
{
public int Slot { get; set; } = 0;
public Type Type { get; set; } = new Type();
}

public class Type
{
public string Name { get; set; } = string.Empty;
}