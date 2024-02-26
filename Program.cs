using MyFirstGame;

Console.CursorVisible = false;

int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight - 2;

int basketPosition = windowWidth / 2;

bool exitGame = false;
string Basket = @"\__/";

int points = 0;
int lives = 5;

Star firstStar = new Star(){PositionX = randomizer.Next(windowWidth)};



Console.SetCursorPosition(basketPosition, windowHeight);
Console.Write(Basket);

while (!exitGame)
{
    MoveBasket();
    StarFall(firstStar);

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

void StarFall(Star star)
{
    while (!Console.KeyAvailable)
    {
        if(star.PositionY  == windowHeight/2)
        {
            var nextStar = new Star(){PositionX = randomizer.Next(windowWidth)};
            StarFall(nextStar);
        }
        if (star.PositionY < windowHeight - 1)
        {
            star.PositionY += 1;
        }
        else
        {
            star.PositionY = 1;
            DeleteStar(windowHeight - 1);
        }

        Thread.Sleep(250);
        Console.SetCursorPosition(star.PositionX, star.PositionY);
        Console.WriteLine('*');
        DeleteStar(star.PositionY - 1);

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
    else if (firstStar.PositionY == windowHeight - 2 && validPositions.Any(position => position == firstStar.PositionX))
    {
        points += 1;
    }
    else if (firstStar.PositionY == windowHeight - 2 && validPositions.Any(position => position != firstStar.PositionX))
    {
        lives -= 1;
    }

}