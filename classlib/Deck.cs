using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using Flurl.Http.Configuration;

public record Deck
{
    public List<Card> deck = new List<Card>();

    public Card drawcard()
    {
        Card holder = deck[0];
        deck.Remove(holder);
        return holder;
    }
    public void add(Card selected)
    {
        deck.Add(selected);
    }
    public int count()
    {
        return deck.Count();
    }
    public Card select(int number)
    {
        return deck[number];
    }
    public void remove(int number)
    {
        deck.Remove(select(number));
    }
    public void shuffle(int randomiser)
    {
        bool swaper = false;
        List<Card> holder = new List<Card>();
        for (int i = 0; i < deck.Count; i++)
        {
            if (swaper == false)
            {
                holder.Add(deck[i]);
                deck.Remove(deck[i]);
                swaper = true;
            }
            else
            {
                swaper = false;
            }
        }
        foreach (Card item in holder)
        {
            deck.Add(item);
        }
        if (randomiser > 0)
        {
            this.shuffle(randomiser - 1);
        }
    }
    public void requestcards()
    {
        string cards = File.ReadAllText("TD.Main\test.json");
        //JsonSerializer.Deserialize<Card>(cards);
        Console.WriteLine(JsonSerializer.Deserialize<Card>(cards));
       
    }

}