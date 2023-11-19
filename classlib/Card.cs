using classlib;
public abstract record Card
{
    public abstract string? gettype();
    public abstract string? getname();
    public abstract string? getPower();
    public abstract string getCost();
    public abstract int Costint();
    public abstract int getStrength();
    public abstract int getHealth();
    public abstract bool getstate();
    public abstract void setState(bool dead);
    Rarity rank{get; set;}
    public abstract void fight(Card target);
}
