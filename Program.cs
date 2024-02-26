int windowWidth = Console.WindowWidth;
int windowHeight = Console.WindowHeight;
int position = 0;

var randomizer = new Random();

while (!Console.KeyAvailable)
{
    Console.CursorVisible = false;
    position++;
    Thread.Sleep(500);

    Console.SetCursorPosition(windowWidth / 2, position -1);
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
    Console.SetCursorPosition(windowWidth / 2, position);
    Console.WriteLine('*');
    Console.WriteLine();
    Console.WriteLine();
}
