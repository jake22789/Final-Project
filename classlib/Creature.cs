using System.Runtime.InteropServices;
using System.Text;
using classlib;
// this is a data type that handles all the actions a creature card could take in magic the gathering.
public record Creature : Card
{
    // this record has a few proporties as seen with counter powe and cost.
    public string? Typename;
    public int counter { get; set; }
    public string? name;
    Rarity rank;
    public int power { get; }
    int toughness { get; }
    string? ability;
    List<Keyword>? key;
    int cost { get; set; }
    public bool state;

// oporator overloading is shown in each of these records one is used for tests and the other for the game. 
    public Creature(string _name, Rarity _rank, int _power, int _toughness, string? _ability,int _cost)
    {
        name = _name;
        rank = _rank;
        power = _power;
        toughness = _toughness;
        ability = _ability;
        counter = 0;
        Typename = "Creature";
        state = true;
        cost = _cost;
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

    // so many polymorphism each of these override functions are found in each of the data types and are exicuted when a function of card is called.
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

    public override string print()
    {
        if (ability == "OriginalType"){
            ability = null;
        }
         StringBuilder text = new StringBuilder();
        text.Append($"----------\n| {getname()} |\n|          |\n|    {getCost()}     |\n|  {ability}        |\n|      {getPower()} |\n|----------|\n");
        return text.ToString();
    }
}