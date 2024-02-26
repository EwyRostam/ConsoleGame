Console.CursorVisible = false;
int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight - 2;

int starPosition = 1;
int basketPosition = windowWidth / 2;

bool exitGame = false;
string Basket = @"\__/";

var randomizer = new Random();

Console.SetCursorPosition(basketPosition, windowHeight);
Console.Write(Basket);

while (!exitGame)
{
    while (!Console.KeyAvailable)
    {
        StarFall();
    }

    MoveBasket();
}

void MoveBasket()
{
    int lastPosition = basketPosition;

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.LeftArrow:
            basketPosition -= 1;
            break;

        case ConsoleKey.RightArrow:
            basketPosition += 1;
            break;
        case ConsoleKey.Escape:
            exitGame = true;
            break;
    }

    Console.SetCursorPosition(lastPosition, windowHeight);
    for (int i = 0; i < Basket.Length; i++)
    {
        Console.Write(" ");
    }

    Console.SetCursorPosition(basketPosition, windowHeight);
    Console.Write(Basket);
}


void DeleteStar(int heightPosition)
{
    Console.SetCursorPosition(0, heightPosition);
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
}

void StarFall()
{
    if (starPosition < windowHeight -1)
    {
        starPosition += 1;
    }
    else
    {
        starPosition = 1;
        DeleteStar(windowHeight -1);
    }

    Thread.Sleep(500);
    Console.SetCursorPosition(windowWidth / 2, starPosition);
    Console.WriteLine('*');
    DeleteStar(starPosition - 1);
}