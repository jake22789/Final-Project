using classlib;

public record Spell : Card
{

    string? name;
    int cost {get; set;}
     public bool state;
    //state determins if the card wone a battle or lost true will leave it in the battlefeald false will send it to the graveyard
    Rarity rank;

    string? ability;
    public Spell(string _name, Rarity _rank, string? _ability,int _cost)
    {
        name = _name;
        rank = _rank;
        ability = _ability;
        cost = _cost;
        state =true;
    }
    public Spell()
    {
        name = "lightning";
        rank = Rarity.common;
        ability = null;
        cost = 2;
        state = true;
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

    public override int getStrength()
    {
        return 0;
    }
    public override bool getstate()
    {
        return state;
    }

    public override void fight(Card target)
    {
        return;
    }

    public override int getHealth()
    {
        return 0;
    }

    public override void setState(bool dead)
    {
        return;
    }
}