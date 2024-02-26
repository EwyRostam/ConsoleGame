int windowWidth = Console.BufferWidth;
int windowHeight = Console.BufferHeight;
int position = 1;

var randomizer = new Random();

while (!Console.KeyAvailable)
{
    Console.CursorVisible = false;

    StarFall();


}


void DeleteStar(int heightPosition)
{
    Console.SetCursorPosition(0, heightPosition);
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
}

void StarFall()
{
    if (position < windowHeight - 2)
    {
        position += 1;
    }
    else
    {
        position = 1;
        DeleteStar(windowHeight - 2);
    }

    Thread.Sleep(500);
    Console.SetCursorPosition(windowWidth / 2, position);
    Console.WriteLine('*');
    DeleteStar(position - 1);
}