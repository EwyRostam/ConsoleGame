using MyFirstGame;

Console.CursorVisible = false;
var randomizer = new Random();

int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight - 2;

int basketPosition = windowWidth / 2;

bool exitGame = false;
string Basket = @"\__/";

int points = 0;
int lives = 5;

var firstStar = new Star(windowHeight);


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

void StarFall(Star firstStar)
{
    while (!Console.KeyAvailable)
    {
        // if(firstStar.PositionY  == windowHeight/2)
        // {
          
        //     StarFall(new Star(windowHeight));
        // }
        if (firstStar.PositionY < windowHeight - 1)
        {
            firstStar.PositionY += 1;
        }
        else
        {
            firstStar.PositionY = 1;
            firstStar.PositionX = randomizer.Next(windowWidth);
            DeleteStar(windowHeight - 1);
        }

        Thread.Sleep(250);
        Console.SetCursorPosition(firstStar.PositionX, firstStar.PositionY);
        Console.WriteLine('*');
        DeleteStar(firstStar.PositionY - 1);

        PointSystem(firstStar);
        if (exitGame)
            break;
    }

}

void PointSystem(Star star)
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
    else if (star.PositionY == windowHeight - 2 && validPositions.Any(position => position == star.PositionX))
    {
        points += 1;
    }
    else if (star.PositionY == windowHeight - 2 && validPositions.Any(position => position != star.PositionX))
    {
        lives -= 1;
    }

}