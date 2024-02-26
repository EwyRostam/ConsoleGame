int windowWidth = Console.WindowWidth;
int windowHeight = Console.WindowHeight;
int position = 1;

var randomizer = new Random();

while (!Console.KeyAvailable)
{
    Console.CursorVisible = false;

    if (position < Console.BufferHeight - 2)
    {
        position += 1;
    }
    else
    {
        position = 1;
        Console.SetCursorPosition(0, Console.BufferHeight - 2);
        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
    }

    Thread.Sleep(500);
    Console.SetCursorPosition(windowWidth / 2, position);
    Console.WriteLine('*');
    Console.SetCursorPosition(0, position - 1);
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
}


