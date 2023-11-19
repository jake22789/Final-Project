using System.Runtime.InteropServices;
using System.Text;
using classlib;
public record Creature : Card
{
    public string? Typename;
    public int counter { get; set; }
    string? name;
    Rarity rank;
    public int power { get; }
    int toughness { get; }
    string? ability;
    List<Keyword>? key;
    int cost { get; set; }
    public bool state;

    public Creature(string _name, Rarity _rank, int _power, int _toughness, string? _ability)
    {
        name = _name;
        rank = _rank;
        power = _power;
        toughness = _toughness;
        ability = _ability;
        counter = 0;
        Typename = "Creature";
        state = true;
    }
    public Creature()
    {
        name = "beetle";
        rank = Rarity.common;
        power = 1;
        toughness = 1;
        ability = null;
        counter = 0;
        cost = 1;
        Typename = "Creature";
        state = true;
    }
    public override string? getname()
    {
        return name;
    }
    public override string? getPower()
    {
        StringBuilder text = new StringBuilder();
        text.Append($"{power}/{toughness}");
        for (int i = 0; i < (name.Count() - 3); i++)
        {
            text.Append(" ");
        }
        return text.ToString();
    }
    public override string getCost()
    {
        StringBuilder text = new StringBuilder();
        text.Append($"{cost}");
        for (int i = 0; i < (name.Count() - 1); i++)
        {
            text.Append(" ");
        }
        return text.ToString();
    }
    public override int Costint()
    {
        return cost;
    }
    public override string? gettype()
    {
        return "Creature";
    }
    public override int getStrength()
    {
        return power;
    }
    public override bool getstate()
    {
        return state;
    }
    public void printcard()
    {
        StringBuilder text = new StringBuilder();
        text.Append($"----------\n| {getname()} |\n|          |\n|    {getCost()}     |\n|          |\n|      {getPower()} |\n|----------|\n");
        Console.Write(text);
    }

    public override void fight(Card target)
    {
        if(target.getStrength()>= toughness){
            state = false;
        }
        if(target.getHealth()<= power){
            target.setState(false);
        }
    }

    public override int getHealth()
    {
        return toughness;
    }

    public override void setState(bool dead)
    {
        state = dead;
    }
}