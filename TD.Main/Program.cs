using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
bool game = true;
int input;
while (game == true)
{
    Console.WriteLine("welcome to a magic the gathering symulator\nPlease select an option\n 1: build a deck\n 2: play a game\n3: exit the program");
    input = getnumberinput(3);
    if(input == 1){
        deckBuilder();
    }
    if(input == 2){
        playgame();
    }
    if (input == 3){
        game = false;
    }
}

void deckBuilder(){

}

void playgame()
{
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
        //player.lowerlife(mistro.AIattack(player));
        checkwin();
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
    void checkwin()
    {
        if (player.playerLife <= 0 || mistro.playerLife <= 0)
        {
            done = true;
        }
        if (player.playerLife <= 0)
        {
            Console.WriteLine("\n\n            player wins!!!!!\n\n");
        }
        if (mistro.playerLife <= 0)
        {
            Console.WriteLine("\n\n            player Loses!!!!!\n\n");
        }
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

