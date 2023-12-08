using System.Runtime;
using classlib;
//this data type handes converting the information recived from the api into a card type that can be used in the game.
public record placeholdercard
{
    public string _name;
    public Rarity _rank;
    public int _power;
    public int _toughness;
    public string? _ability;
    public string cardtype;
    public int _cost;
    public placeholdercard(){

    }
    public placeholdercard(string cardrep)
    {
        string[] C = cardrep.Split('"');
        for (int i = 0; i < C.Count(); i++)
        {
            if (C[i] == "ManaCost")
            {
                string holder = C[i + 2];
                _cost = holder[2] - 120 +1;
                holder = "0";
            }
            if (C[i] == "Rarity")
            {
                if (C[i + 2] == "Common")
                {
                    _rank = Rarity.common;
                }
                if (C[i + 2] == "Uncommon")
                {
                    _rank = Rarity.uncommon;
                }
                if (C[i + 2] == "Rare")
                {
                    _rank = Rarity.rare;
                }
                if (C[i + 2] == "Ledgendary")
                {
                    _rank = Rarity.ledgendary;
                }
            }
            if (C[i] == "Name")
            {
                _name = C[i + 2];

            }
            if (C[i] == "OriginalText")
            {
                _ability = C[i + 2];

            }
            if (C[i] == "Type")
            {
                cardtype = C[i + 2].Split(" ")[0];

            }
            if (C[i] == "Toughness")
            {
                //if it trys to assighn a number to power an toughness when there is none like a lland spell or enchantment those dont have data so this exception handles that.
                try{
                _toughness = int.Parse(C[i + 2]);
                }catch{
                    _toughness = 0;
                }

            }
            if (C[i] == "Power")
            {
                try{
                _power = int.Parse(C[i + 2]);
                }catch{
                        _power = 0;
                }

            }
            
        }

    }

    public Card NewCard(){
        if(cardtype == "Creature"){
            Creature target = new Creature(_name,_rank,_power,_toughness,_ability,_cost);
            return target;
        }
        if(cardtype == "Land"){
            Land target = new Land(_name,_rank);
            return target;
        }
        if(cardtype == "Sorcery" ||cardtype == "Instant" ){
            Spell target = new Spell(_name,_rank,_ability,_cost);
            return target;
        }
        if(cardtype == "Enchantment"){
            Enchantment target = new Enchantment(_name,_rank,_ability,_cost);
            return target;
        }
        Land nope = new Land();
        return nope;
    }
}
