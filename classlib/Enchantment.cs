using classlib;

public record Enchantment : Card
{

    string? name { get; set; }
    Rarity rank { get; set; }
    int cost { get; set; }
    string? ability;

    public Enchantment(string _name, Rarity _rank, string? _ability, int _cost)
    {
        name = _name;
        rank = _rank;
        ability = _ability;
        cost = _cost;
    }
    public Enchantment()
    {
        name = "counter";
        rank = Rarity.common;
        ability = null;
        cost = 3;
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
        return"enchantment";
    }

    public override int getStrength()
    {
        return 0;
    }
}