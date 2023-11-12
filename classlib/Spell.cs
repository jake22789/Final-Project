using classlib;

public record Spell : Card
{

    string? name;
    int cost {get; set;}

    Rarity rank;

    string? ability;
    public Spell(string _name, Rarity _rank, string? _ability,int _cost)
    {
        name = _name;
        rank = _rank;
        ability = _ability;
        cost = _cost;
    }
    public Spell()
    {
        name = "lightning";
        rank = Rarity.common;
        ability = null;
        cost = 2;
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