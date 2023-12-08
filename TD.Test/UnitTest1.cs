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
    [Test]
    public void fightingbothdie()
    {
        Creature beetle = new Creature();
        Creature beetle2 = new Creature();
        beetle.fight(beetle2);
        if(beetle.state == false){
        Assert.AreEqual(beetle2.state,beetle.state);
        }else{
            Assert.Fail();
        }
    }
    [Test]
    public void fightingbothlive()
    {
        Creature worm = new Creature("worm",Rarity.common,0,1," ",0);
        Creature worm2 = new Creature("worm",Rarity.common,0,1," ",0);
        worm.fight(worm2);
        if(worm.state == true){
        Assert.AreEqual(worm.state,worm2.state);
        }else{
            Assert.Fail();
        }
    }
    [Test]
    public void fightingonedie()
    {
        Creature beetle = new Creature();
        Creature cow = new Creature("cow",Rarity.common,5,5," ",0);
        beetle.fight(cow);
        if(cow.state == false){
            Assert.Fail();
        }
        if(beetle.state == false){
            Assert.Pass();
        }
        else{
            Assert.Fail();
        }

    }
    [Test]
    public void creatureVSSpell()
    {
        Creature worm = new Creature("worm",Rarity.common,0,1," ",0);
        Spell lightning = new Spell();
        worm.fight(lightning);
        if(worm.state == true){
        Assert.AreEqual(worm.state,lightning.state);
        }else{
            Assert.Fail();
        }
    }
    [Test]
    public void creatureVSland()
    {
        Creature worm = new Creature("worm",Rarity.common,0,1," ",0);
        Land green = new Land();
        worm.fight(green);
        if(worm.state == true){
        Assert.AreEqual(worm.state,green.state);
        }else{
            Assert.Fail();
        }
    }
    [Test]
    public void creatureVSEnchantment()
    {
        Creature worm = new Creature("worm",Rarity.common,0,1," ",0);
        Enchantment counter = new Enchantment();
        worm.fight(counter);
        if(worm.state == true){
        Assert.AreEqual(worm.state,counter.state);
        }else{
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
        if(player1.battlefeald.deck.Count == 2){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void placeholdercardtest()
    {
        placeholdercard test = new placeholdercard();
        test.cardtype="Creature";
        test._name = "beetle";
        Creature bug = new Creature();
        Assert.AreEqual(test.NewCard().getname(), bug.name);
    }
}