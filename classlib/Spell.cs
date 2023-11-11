using classlib;

public record Spell : Card
{

    string? name;
    int cost {get; set;}

    Rarity rank;

    string? ability;
    Spell(string _name, Rarity _rank, string? _ability)
    {
        name = _name;
        rank = _rank;
        ability = _ability;
    }
    public override string? getname()
    {
        return name;
    }

    public override string? getPower()
    {
        return null;
    }
    public override string getCost()
    {
        return $"{cost}";
    }
    public override int Costint()
    {
        return cost;
    }

    public override string? gettype()
    {
        return "spell";
    }
}