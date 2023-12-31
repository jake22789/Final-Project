using System.ComponentModel;
using classlib;
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

        Deck stompy = new Deck();
        for (int i = 0; i < 50; i++)
        {
            Land green = new Land();
            stompy.add(green);
        }
        Game player1 = new Game(stompy);
        Assert.AreSame(stompy, player1.drawpile);
    }
    [Test]
    public void drawcardtest()
    {
        //test to see if draw card works

        Deck stompy = new Deck();
        for (int i = 0; i < 50; i++)
        {
            Land green = new Land();
            stompy.add(green);
        }
        Land expected = new Land();
        // sence i used records i can compare the two records to make sure that the porperties are the same
        if (expected == stompy.drawcard())
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }
    [Test]
    public void drawcardtest2()
    {
        //test to see if draw card is removeing that previous card from deck

        Deck stompy = new Deck();
        Land green = new Land();
        Creature bug = new Creature();
        stompy.add(green);
        stompy.add(bug);
        Land expected = new Land();
        // sence i used records i can compare the two records to make sure that the porperties are the same
        if (expected == stompy.drawcard())
        {
            if(expected!= stompy.drawcard()){
                Assert.Pass();
            }
        }
        else
        {
            Assert.Fail();
        }
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
        stompy.add(green);
        stompy.add(beetle);
        stompy.add(counter);
        stompy.add(lightning);
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
        Assert.AreNotEqual(0, player1.attack(other));
    }
    [Test]
    public void fightingbothdie()
    {
        Creature beetle = new Creature();
        Creature beetle2 = new Creature();
        beetle.fight(beetle2);
        if (beetle.state == false)
        {
            Assert.AreEqual(beetle2.state, beetle.state);
        }
        else
        {
            Assert.Fail();
        }
    }
    [Test]
    public void fightingbothlive()
    {
        Creature worm = new Creature("worm", Rarity.common, 0, 1, " ", 0);
        Creature worm2 = new Creature("worm", Rarity.common, 0, 1, " ", 0);
        worm.fight(worm2);
        if (worm.state == true)
        {
            Assert.AreEqual(worm.state, worm2.state);
        }
        else
        {
            Assert.Fail();
        }
    }
    [Test]
    public void fightingonedie()
    {
        Creature beetle = new Creature();
        Creature cow = new Creature("cow", Rarity.common, 5, 5, " ", 0);
        beetle.fight(cow);
        if (cow.state == false)
        {
            Assert.Fail();
        }
        if (beetle.state == false)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }

    }
    [Test]
    public void creatureVSSpell()
    {
        Creature worm = new Creature("worm", Rarity.common, 0, 1, " ", 0);
        Spell lightning = new Spell();
        worm.fight(lightning);
        if (worm.state == true)
        {
            Assert.AreEqual(worm.state, lightning.state);
        }
        else
        {
            Assert.Fail();
        }
    }
    [Test]
    public void creatureVSland()
    {
        Creature worm = new Creature("worm", Rarity.common, 0, 1, " ", 0);
        Land green = new Land();
        worm.fight(green);
        if (worm.state == true)
        {
            Assert.AreEqual(worm.state, green.state);
        }
        else
        {
            Assert.Fail();
        }
    }
    [Test]
    public void creatureVSEnchantment()
    {
        Creature worm = new Creature("worm", Rarity.common, 0, 1, " ", 0);
        Enchantment counter = new Enchantment();
        worm.fight(counter);
        if (worm.state == true)
        {
            Assert.AreEqual(worm.state, counter.state);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Test]
    public void attackingchangesboardstateV1()
    {
        Land green = new Land();
        Creature beetle = new Creature();
        Creature beetle2 = new Creature();
        Game other = new Game();
        Game player1 = new Game();
        player1.battlefeald.deck.Add(beetle);
        player1.battlefeald.deck.Add(beetle2);
        player1.battlefeald.deck.Add(green);
        other.battlefeald.deck.Add(beetle);
        other.battlefeald.deck.Add(green);
        player1.attack(other);
        if (player1.battlefeald.deck.Count == 2)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [Test]
    public void placeholdercreaturecardtest()
    {
        // test to see if placeholder can be converted into creature card type
        placeholdercard test = new placeholdercard();
        test.cardtype = "Creature";
        test._name = "beetle";
        test._power = 1;
        test._toughness = 1;
        Creature expected = new Creature();
       Assert.That(expected.getname(), Is.EqualTo(test.NewCard().getname()));
    }
    [Test]
    public void placeholderlandcardtest()
    {
        // test to see if placeholder can be converted into land card type
        placeholdercard test = new placeholdercard();
        test.cardtype = "Land";
        test._name = "dessert";
        //calls constructor for a default card
        Land expected = new Land();
       Assert.That(expected.getname(), Is.EqualTo(test.NewCard().getname()));
    }
    [Test]
    public void placeholderSpellcardtest()
    {
        // test to see if placeholder can be converted into spell card type
        placeholdercard test = new placeholdercard();
        test.cardtype = "Sorcery";
        test._name = "lightning";
        Spell expected = new Spell();
        Assert.That(expected.getname(), Is.EqualTo(test.NewCard().getname()));
    }
    [Test]
    public void placeholderEnchantmentCardtest()
    {
        // test to see if placeholder can be converted into enchantment card type
        placeholdercard test = new placeholdercard();
        test.cardtype = "Creature";
        test._name = "counter";
        Enchantment expected = new Enchantment();
        Assert.That(expected.getname(), Is.EqualTo(test.NewCard().getname()));
    }
    [Test]
    public void creaturecardprinttest()
    {
        string expectedtext = $"----------\n| beetle |\n|          |\n|    0          |\n|          |\n|      1/1    |\n|----------|\n";
        placeholdercard test = new placeholdercard();
        test.cardtype = "Creature";
        test._name = "beetle";
        test._power = 1;
        test._toughness = 1;
        Creature bug = new Creature();
        Assert.AreEqual(expectedtext, test.NewCard().print());
    }
    [Test]
    public void landcardprinttest()
    {
        string expectedtext = $" ----------\n| forest  |\n|          |\n|   0     |\n|          |\n|          |\n ---------- \n";
        placeholdercard test = new placeholdercard();
        test.cardtype = "Land";
        test._name = "forest";
        Assert.AreEqual(expectedtext, test.NewCard().print());
    }
    [Test]
    public void spellcardprinttest()
    {
        string expectedtext = $"----------\n| Counter |\n|          |\n|    3     |\n|          |\n|place a 1/1 counter on target creature|\n ---------- \n";
        placeholdercard test = new placeholdercard();
        test.cardtype = "Sorcery";
        test._name = "Counter";
        test._ability = "place a 1/1 counter on target creature";
        test._cost = 3;
        Assert.AreEqual(expectedtext, test.NewCard().print());
    }
    [Test]
    public void Enchantmentcardprinttest()
    {
        string expectedtext = $"----------\n| doubling season |\n|          |\n|    3     |\n|          |\n|if a  token creature or +1/+1 counter would be placed on the beatlfeald two are placed instead|\n ---------- \n";
        placeholdercard test = new placeholdercard();
        test.cardtype = "Enchantment";
        test._name = "doubling season";
        test._ability = "if a  token creature or +1/+1 counter would be placed on the beatlfeald two are placed instead";
        test._cost = 3;
        Assert.AreEqual(expectedtext, test.NewCard().print());
    }
    [Test]
    public void testsThatAPIIsConvertedToCard(){
        //if this test fails it could be because the file its looking for is gone if that is the case run the commented code and past the first object in test.json to that file its in bin so it might get ignored
        //string thisFile = "paset here";
        //File.WriteAllText("testfile.json",thisFile);
        Creature angel = new Creature("Ancestors Chosen",Rarity.uncommon,4,4,"First strike (This creature deals combat damage before creatures without first strike.)\\nWhen Ancestors Chosen comes into play, you gain 1 life for each card in your graveyard.",6);
        string Jsonstring = File.ReadAllText("testfile.json");
        placeholdercard test = new placeholdercard(Jsonstring);
        Assert.AreEqual(angel.print(), test.NewCard().print());
         
    } 

}
