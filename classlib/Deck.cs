using System.Threading.Channels;

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
    public int count(){
        return deck.Count();
    }
    public Card select(int number){
        return deck[number];
    }
    public void remove(int number){
        deck.Remove(select(number));
    }

}