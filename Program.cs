int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight -2;
int starPosition = 1;
int basketPosition = windowWidth/2;
string Basket = @"\__/";

var randomizer = new Random();

while (!Console.KeyAvailable)
{
    Console.CursorVisible = false;

    StarFall();

    Console.SetCursorPosition(basketPosition, windowHeight);
    Console.WriteLine(Basket);
    ConsoleKey move = Console.ReadKey().Key;

    switch(move)
    {
        case ConsoleKey.LeftArrow :
        DeleteStar(windowHeight);
        basketPosition -= 1;
        break;

        case ConsoleKey.RightArrow :
        DeleteStar(windowHeight);
        basketPosition += 1;
        break;

        default:
        break;
    }
    
}


void DeleteStar(int heightPosition)
{
    Console.SetCursorPosition(0, heightPosition);
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
}

void StarFall()
{
    if (starPosition < windowHeight)
    {
        starPosition += 1;
    }
    else
    {
        starPosition = 1;
        DeleteStar(windowHeight);
    }

    Thread.Sleep(500);
    Console.SetCursorPosition(windowWidth / 2, starPosition);
    Console.WriteLine('*');
    DeleteStar(starPosition - 1);
}