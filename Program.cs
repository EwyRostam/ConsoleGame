Console.CursorVisible = false;

int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight - 2;

var randomizer = new Random();

int nextStarPositionX = randomizer.Next(windowWidth);
int nextStarPositionY = 1;

int firstStarPositionX = randomizer.Next(windowWidth);
int firstStarPositionY = 1;

int basketPosition = windowWidth / 2;

bool exitGame = false;
string Basket = @"\__/";

int points = 0;
int lives = 5;



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
        if (firstStarPositionY < windowHeight - 1)
        {
            firstStarPositionY += 1;
        }
        else
        {
            firstStarPositionY = 1;
            DeleteStar(windowHeight - 1);
        }

        Thread.Sleep(250);
        Console.SetCursorPosition(firstStarPositionX, firstStarPositionY);
        Console.WriteLine('*');
        DeleteStar(firstStarPositionY - 1);

        PointSystem();
        if (exitGame)
            break;
    }

}

void PointSystem()
{
    List<int> validPositions = new();
    for(var i = 0; i < Basket.Length; i++)
    {
         validPositions.Add(basketPosition + i);
    }

    if (lives < 1)
    {
        exitGame = true;
    }
    else if (firstStarPositionY == windowHeight - 2 && validPositions.Any(position => position == firstStarPositionX))
    {
        points += 1;
    }
    else if (firstStarPositionY == windowHeight - 2 && validPositions.Any(position => position != firstStarPositionX))
    {
        lives -= 1;
    }

}