Console.CursorVisible = false;
int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight - 2;

int starPositionX = windowWidth / 2;
int starPositionY = 1;

int basketPosition = windowWidth / 2;

bool exitGame = false;
string Basket = @"\__/";

int points = 0;
int lives = 5;

var randomizer = new Random();

Console.SetCursorPosition(basketPosition, windowHeight);
Console.Write(Basket);

while (!exitGame)
{
    MoveBasket();
    StarFall();

}

Console.WriteLine($"Game ended! Your points are {points}");

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
    while (!Console.KeyAvailable)
    {
        if (starPositionY < windowHeight - 1)
        {
            starPositionY += 1;
        }
        else
        {
            starPositionY = 1;
            DeleteStar(windowHeight - 1);
        }

        Thread.Sleep(250);
        Console.SetCursorPosition(starPositionX, starPositionY);
        Console.WriteLine('*');
        DeleteStar(starPositionY - 1);

        PointSystem();
        if (exitGame)
            break;
    }

}

void PointSystem()
{
    if (lives < 1)
    {
        exitGame = true;
    }
    else if (starPositionY == windowHeight - 2 && starPositionX == basketPosition)
    {
        points += 1;
    }
    else if (starPositionY == windowHeight - 2 && starPositionX != basketPosition)
    {
        lives -= 1;
    }

}