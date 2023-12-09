using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.Json;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
IMtgServiceProvider serviceProvider = new MtgServiceProvider();
ICardService service = serviceProvider.GetCardService();
var result = await service.AllAsync();

if (result.IsSuccess)
{
    var value = result.Value;

}
else
{
    var exception = result.Exception;
}
string cardsrep = JsonSerializer.Serialize(result);
bool game = true;
int input;
Console.Clear();
while (game == true)
{
    Console.WriteLine("welcome to a magic the gathering symulator\nPlease select an option\n 1: build a deck\n 2: play a game\n 3: exit the program");
    input = getmenunumber();
    if (input == 1)
    {
        deckBuilder(cardsrep);
    }
    if (input == 2)
    {
        playgame();
    }
    if (input == 3)
    {
        game = false;
    }
}

void deckBuilder(string jsncards)
{
    Console.WriteLine("welcome to the deck builder\n here you will make new decks or modify existing decks from the card library.\n would you like to \n 1: modify existing deck \n 2: make a new deck \n 3: exit the program");
    bool done = false;
    while (done == false)
    {
        int input;
        input = getmenunumber();
        if (input == 1)
        {
            modifyDeck();
        }
        if (input == 2)
        {
            buildNewDeck(jsncards);
        }
        if (input == 3)
        {
            done = true;
        }

        void modifyDeck()
        {

        }
        void buildNewDeck(string jcards)
        {
            Console.WriteLine("what would you like to call your new deck?");
            var input = Console.ReadLine();
            Deck builder = new Deck();
            builder.setname(input);
            
            string[] cards = jcards.Split("Artist");
            cards = cards.Skip(1).ToArray();

            for(int i = 0; i<cards.Length;i++)
            {
                Console.Clear();
                placeholdercard target = new placeholdercard(cards[i]);
                Console.Write(target.NewCard().print());
                Console.WriteLine("would you like to add this card to your deck Y/N \n if you would like to leave card builder input: 0");
                string _input = Console.ReadLine();
                if (_input == "y" || _input == "Y")
                {
                    builder.add(target.NewCard());
                }
                if(_input == "0"){
                    i = cards.Length;
                }
                
            }
            //useing file to save your decks
            string fileDeck = JsonSerializer.Serialize(builder);
            File.WriteAllText(builder.getname(),fileDeck);
           

        }
    }
}

void playgame()
{
    
    Game mistro = new Game();
    bool done = false;
    Console.Clear();
    Game player = new Game(getdeck());
    mistro.setname("Mistro");

    player.drawcard();
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
    // use of recursion to validate user input
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
int getmenunumber()
{
    int input;
    try
    {
        input = int.Parse(Console.ReadLine());
        if (input > 4 || input < 0)
        {
            throw new Exception();
        }
    }
    catch
    {
        Console.WriteLine("that input was invalad please input a number between 1 and 3");
        return getmenunumber();
    }
    return input;
}
Deck getdeck(){
 Console.WriteLine("what deck would you like to play with? if you have not built a deck then input 0");
    string name = Console.ReadLine();
    if(name == "0"){
        Deck stompy = new Deck();
        for (int i = 0; i < 30; i++)
        {
            Land green = new Land();
            stompy.add(green);
        }
        for (int i = 0; i < 30; i++)
        {
            Creature bug = new Creature();
            stompy.add(bug);
        }
        stompy.shuffle(27);
        return stompy;
        
    }
    try{
        string jsondeck = File.ReadAllText(name);
        return JsonSerializer.Deserialize<Deck>(jsondeck);

    }catch{
        Console.WriteLine("im sorry i could not find that deck.");
        return getdeck();
    }
    
}
