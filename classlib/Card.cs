using classlib;
public abstract record Card
{
    public abstract string? gettype();
    public abstract string? getname();
    public abstract string? getPower();
    public abstract string getCost();
    public abstract int Costint();
    public abstract int getStrength();
    Rarity rank{get; set;}
}
