using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

public record Game
{
    public int playerLife;
    public int player2Life;
    public int boardsize;
    public int mana;
    public int handsize;
    public Deck? drawpile = new Deck();
    Deck? graveyard = new Deck();
    Deck? hand = new Deck();
    Deck? battlefeald = new Deck();
    Deck? exile = new Deck();

    public int Getlife()
    {
        return playerLife;
    }

    public Game()
    {
        Land green = new Land();
        Creature bug = new Creature();
        playerLife = 40;
        player2Life = 40;
        boardsize = 2;
        handsize = 7;
        for (int i = 0; i < 50; i++)
        {
            drawpile.add(bug);
            drawpile.add(green);
        }
        for (int i = 0; i < 7; i++)
        {
            hand.add(drawpile.drawcard());
        }
    }
    public Game(Deck selected)
    {
        playerLife = 40;
        player2Life = 40;
        boardsize = 2;
        handsize = 7;
        drawpile = selected;
    }
    public void drawcard()
    {
        if (drawpile.drawcard() == null)
        {
            Console.WriteLine("no card to draw you lose");
            playerLife = 0;
            return;
        }
        hand.add(drawpile.drawcard());

    }
    public void playcard(int selected)
    {
        int cardcost = hand.select(selected).Costint();
        if (cardcost <= mana)
        {
            battlefeald.add(hand.select(selected));
            hand.remove(selected);
            mana = mana - cardcost;
        }
        else
        {
            Console.WriteLine("that card costs too much");
            return;
        }

    }
    void killcard(Card selected)
    {
        graveyard.add(selected);
    }
    public void printGame()
    {
        StringBuilder text = new StringBuilder();
        for (int i = 0; i < (boardsize); i++)
        {
            text.Append("----------");
        }
        text.Append("\n");
        text.Append($"|life points: {playerLife}");
        text.Append($" mana :{mana}");
        text.Append("|\n");
        text.Append("\n");
        foreach (Card item in battlefeald.deck)
        {
            text.Append(item.getname());
            text.Append("  ");
        }
        text.Append("\n");
        foreach (Card item in battlefeald.deck)
        {
            text.Append(item.getCost());
            text.Append("  ");
        }
        text.Append("\n");
        foreach (Card item in battlefeald.deck)
        {
            text.Append(item.getPower());
            text.Append("  ");
        }

        text.Append("\n");
        text.Append($"player2Life :{player2Life}");
        text.Append("\n");
        for (int i = 0; i < (boardsize); i++)
        {
            text.Append("----------");
        }
        text.Append("|\n");
        text.Append("|\n");
        Console.Write(text);
    }
    public void printHand()
    {
        StringBuilder text = new StringBuilder();
        foreach (Card item in hand.deck)
        {
            text.Append("----------");
        }
        text.Append("\n");
        foreach (Card item in hand.deck)
        {
            text.Append(item.getname());
            text.Append("  ");
        }
        text.Append("\n");
        foreach (Card item in hand.deck)
        {
            text.Append(item.getCost());
            text.Append("  ");
        }
        text.Append("\n");
        foreach (Card item in hand.deck)
        {
            text.Append(item.getPower());
            text.Append("  ");
        }
        text.Append("\n");
        foreach (Card item in hand.deck)
        {
            text.Append("----------");
        }
        text.Append("|\n");
        text.Append($" mana :{mana}\n");
        Console.Write(text);
    }
    public int attackWith(Game target)
    {
        if (battlefeald.deck != null)
        {
            string input;
            int attackpower = 0;
            IEnumerable<Card> attacking = from Card in battlefeald.deck where Card.gettype() == "Creature" select Card;
            IEnumerable<Card> targetattacking = from Card in target.battlefeald.deck where Card.gettype() == "Creature" select Card;
            List<Creature> holder = new List<Creature>();
            List<Creature> defender = new List<Creature>();
            foreach(Creature item in targetattacking){
                defender.Append(item);
            }
            
            foreach (Creature item in attacking)
            {
                Console.WriteLine($"would you like to attack with {item.getname()} Y/N {attackpower}");
                input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    holder.Append(item);
                }
            }
            if (targetattacking != null)
            {
                int defendersize = targetattacking.Count();
                if (holder.Count == defendersize){
                    for(int i=0; i<holder.Count;i++){
                        if(holder[i].defend(defender[i]) == 0){
                            killcard(holder[i]);
                            holder.Remove(holder[i]);
                            battlefeald.remove(i);
                        }
                        if(holder[i].defend(defender[i]) == 1){
                            killcard(defender[i]);
                            defender.Remove(defender[i]);
                            target.battlefeald.remove(i);
                        }
                        if(holder[i].defend(defender[i]) == 2){
                            killcard(holder[i]);
                            holder.Remove(holder[i]);
                            battlefeald.remove(i);
                            killcard(defender[i]);
                            defender.Remove(defender[i]);
                            target.battlefeald.remove(i);
                        }
                        if(holder[i].defend(defender[i]) == 3){
                            
                        }
                    }
                }
                

            }

            foreach (Creature item in holder)
            {
                attackpower = attackpower + item.power;
            }
            return attackpower;
        }
        return 0;
    }
    public void upkeep(Game target)
    {
        mana = 0;
        foreach (Card item in battlefeald.deck)
        {
            if (item.getname() == "dessert")
                mana++;
        }
        player2Life = target.playerLife;
    }
}
