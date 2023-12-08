
using System.Text;
using classlib;
// this is another class deffinition
public record Land : Card
{
    string? name;
    Rarity rank;
    color type;
     public bool state;
    

    public Land(string? _name, Rarity _rank)
    {
        name = _name;
        rank = _rank;
        state = true;
    }
    //this oporator overloading is used as a default card if the program runsinto a proplum identifying a card for any reason this card is displayed.
     public Land()
    {
        name = "dessert";
        rank = Rarity.common;
        type = color.green;
        state = true;
    }

    public override string? getname()
    {
        return name;
    }
    public override string? getPower()
    {
        StringBuilder text =new StringBuilder();
        foreach(char letter in name){
            text.Append(" ");
        }
        return text.ToString();
    }

    public override string getCost()
    {

        StringBuilder text = new StringBuilder();
        text.Append("0");
        for(int i=0;i < (name.Count()-1); i++){
            text.Append(" ");
        }
        return text.ToString();
    }

    public override int Costint()
    {
        return 0;
    }

    public override string? gettype()
    {
        return"land";
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

    public override void print()
    {
         StringBuilder text = new StringBuilder();
        text.Append($" ----------\n| {getname()}  |\n|          |\n|   {getCost()}|\n|          |\n|          |\n ---------- \n");
        Console.Write(text);
    }
}