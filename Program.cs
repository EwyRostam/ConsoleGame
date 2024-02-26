int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight -2;
int position = 1;
string Basket = @"\__/";

var randomizer = new Random();

while (!Console.KeyAvailable)
{
    Console.CursorVisible = false;

    StarFall();

    Console.SetCursorPosition(windowWidth / 2, windowHeight);
    Console.WriteLine(Basket);
}


void DeleteStar(int heightPosition)
{
    Console.SetCursorPosition(0, heightPosition);
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
}

void StarFall()
{
    if (position < windowHeight)
    {
        position += 1;
    }
    else
    {
        position = 1;
        DeleteStar(windowHeight);
    }

    Thread.Sleep(500);
    Console.SetCursorPosition(windowWidth / 2, position);
    Console.WriteLine('*');
    DeleteStar(position - 1);
}