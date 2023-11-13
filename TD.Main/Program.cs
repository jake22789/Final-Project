using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

Game player = new Game();
Game mistro = new Game();
bool done = false;
Console.Clear();
Console.WriteLine("what is the name of your deck?");
string name = Console.ReadLine();
player.setname(name);
mistro.setname("Mistro");
while (done == false)
{
    //player turn
    player.upkeep(mistro);
    player.drawcard();
    player.printGame();
    player.printHand();
    player.playcard(getnumberinput(player.handsize));
    while (turndone() == false)
    {
        player.printHand();
        player.playcard(getnumberinput(player.handsize));
    }
    mistro.lowerlife(player.attack(mistro));
    mistro.upkeep(player);
    mistro.drawcard();
    mistro.playcard(1);
    Console.Clear();
    mistro.printGame();
    player.lowerlife(mistro.AIattack(player));


    // win conditions
    if (player.playerLife <= 0 || mistro.playerLife <= 0)
    {
        done = true;
    }

}

int getnumberinput(int handsize)
{
    int input;
    Console.WriteLine("what card would you like to play? : 1-7");
    try
    {
        input = int.Parse(Console.ReadLine()) - 1;
        if (input > handsize || input < 0)
        {
            throw new Exception();
        }
    }
    catch
    {
        Console.WriteLine("that input was invalad please input a number");
        return getnumberinput(handsize);
    }
    return input;
}
bool turndone()
{
    if (player.mana <= 0 || player.handsize <= 0)
    {
        return true;
    }
    Console.WriteLine("are you done with your turn? y/n");
    string? input = Console.ReadLine();
    if (input == "y" || input == "Y" || input == "Yes")
    {
        return true;
    }
    else
    {
        return false;
    }
}
