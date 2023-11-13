using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;

namespace TD.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //test to see if a prebuilt deck can be used.
        Land green = new Land();
        Deck stompy = new Deck();
        for (int i = 0; i < 50; i++)
        {
            stompy.add(green);
        }
        Game player1 = new Game(stompy);
        Assert.AreSame(stompy, player1.drawpile);
    }
    [Test]
    public void Carddeck()
    {
        //test to see if deck can have each card type
        Land green = new Land();
        Creature beetle = new Creature();
        Enchantment counter = new Enchantment();
        Spell lightning = new Spell();
        bool Creature = false;
        bool land = false;
        bool enchantment = false;
        bool spell = false;

        Deck stompy = new Deck();
        for (int i = 0; i < 50; i++)
        {
            stompy.add(green);
        }
        for (int i = 0; i < 25; i++)
        {
            stompy.add(beetle);
        }
        for (int i = 0; i < 10; i++)
        {
            stompy.add(counter);
        }
        for (int i = 0; i < 15; i++)
        {
            stompy.add(lightning);
        }
        foreach (Card item in stompy.deck)
        {
            if (item.gettype() == "land")
            {
                land = true;
            }
            if (item.gettype() == "spell")
            {
                spell = true;
            }
            if (item.gettype() == "Creature")
            {
                Creature = true;
            }
            if (item.gettype() == "enchantment")
            {
                enchantment = true;
            }
        }
        if (land)
        {
            if (spell)
            {
                if (Creature)
                {
                    if (enchantment)
                    {
                        Assert.Pass();
                    }
                }
            }
        }
        Assert.Fail();

    }
    [Test]
    public void shuffledeck()
    {
        //test to see if deck can have each card type
        Land green = new Land();
        Creature beetle = new Creature();
        Enchantment counter = new Enchantment();
        Spell lightning = new Spell();

        Deck stompy = new Deck();
        for (int i = 0; i < 50; i++)
        {
            stompy.add(green);
        }
        for (int i = 0; i < 25; i++)
        {
            stompy.add(beetle);
        }
        for (int i = 0; i < 10; i++)
        {
            stompy.add(counter);
        }
        for (int i = 0; i < 15; i++)
        {
            stompy.add(lightning);
        }
        Deck original = new Deck();
        foreach (Card item in stompy.deck)
        {
            original.add(item);
        }
        stompy.shuffle(2);
        Assert.AreNotEqual(original.deck[0], stompy.deck[0]);
    }

    [Test]
    public void attackingReturnsNumber()
    {
         Land green = new Land();
        Creature beetle = new Creature();
        Enchantment counter = new Enchantment();
        Spell lightning = new Spell();
        Deck stompy = new Deck();
        Game other = new Game();
        Game player1 = new Game();
        for (int i = 0; i < 50; i++)
        {
            stompy.add(green);
        }
        for (int i = 0; i < 25; i++)
        {
            stompy.add(beetle);
        }
        for (int i = 0; i < 10; i++)
        {
            stompy.add(counter);
        }
        for (int i = 0; i < 15; i++)
        {
            stompy.add(lightning);
        }
        player1.battlefeald.deck.Add(beetle);
        Assert.AreNotEqual(0,player1.attack(other));
    }

}