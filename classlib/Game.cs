using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

// this is another class definition that decided major things of the game.
public record Game
{
    string name;
    public int playerLife;
    public int player2Life;
    public int boardsize;
    public int mana;
    public int handsize;
    bool landplayed;
    public Deck? drawpile = new Deck();
    Deck? graveyard = new Deck();
    Deck? hand = new Deck();
    public Deck? battlefeald = new Deck();
    Deck? exile = new Deck();

    public int Getlife()
    {
        return playerLife;
    }

    public void lowerlife(int attack)
    {
        playerLife = playerLife - attack;
    }
    public void setname(string _name)
    {
        name = _name;
    }
    public Game()
    {

        playerLife = 40;
        player2Life = 40;
        boardsize = 2;
        handsize = 7;
        for (int i = 0; i < 50; i++)
        {
            Land green = new Land();
            Creature bug = new Creature();
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
        for (int i = 0; i < 6; i++)
        {
            hand.add(drawpile.drawcard());
        }
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
        if (hand.select(selected).gettype() == "land")
        {
            if (landplayed == true)
            {
                Console.WriteLine("you have already played a land this turn");
                return;
            }
            else
            {
                landplayed = true;
            }
        }
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
        text.Append($"|{name} life: {playerLife}");
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
    public int attack(Game target)
    {
        int damage = 0;
        int index = 0;
        foreach (var item in target.battlefeald.deck)
        {
            item.fight(battlefeald.deck[index]);
            index++;
            if (index > battlefeald.deck.Count)
            {
                index--;
            }
        }
        cleanup();
        target.cleanup();
        foreach (var item in battlefeald.deck)
        {
            damage = damage + item.getStrength();
        }
        return damage;

    }
    public void upkeep(Game target)
    {
        mana = 0;
        landplayed = false;
        foreach (Card item in battlefeald.deck)
        {
            if (item.getname() == "dessert")
                mana++;
        }
        player2Life = target.Getlife();
    }
    public int AIattack(Game target)
    {
        int attackpower = 0;
        IEnumerable<Card> attacking = from Card in battlefeald.deck where Card.gettype() == "Creature" select Card;
        List<Creature> holder = new List<Creature>();
        if (battlefeald != null)
        {
            foreach (Creature item in attacking)
            {
                holder.Append(item);
            }
            foreach (Creature item in target.battlefeald.deck)
            {

            }
            foreach (Creature item in holder)
            {
                attackpower = attackpower + item.power;
            }
            return attackpower;
        }
        else
        {
            return 0;
        }

    }
    public void cleanup()
    {
        List<Card> dead = new List<Card>();
        foreach (Card item in battlefeald.deck)
        {
            if (item.getstate() == false)
            {
                killcard(item);
                dead.Add(item);
            }
        }
        foreach (Card item in dead)
        {
            battlefeald.deck.Remove(item);
        }
    }
    public void defend(List<Creature> attacking)
    {
        printbattlefeald();
        int input = 0;
        foreach (Card item in attacking)
        {
            //print card();
            Console.WriteLine("what card you you like to block this one?");
            input = int.Parse(Console.ReadLine());
            if (input == 0)
            {

            }
        }

    }
    public void printbattlefeald()
    {
        StringBuilder text = new StringBuilder();
        foreach (Card item in battlefeald.deck)
        {
            text.Append("----------");
        }
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
        foreach (Card item in battlefeald.deck)
        {
            text.Append("----------");
        }
        text.Append("|\n");
        text.Append($" mana :{mana}\n");
        Console.Write(text);
    }
}
