int windowWidth = Console.WindowWidth;
int windowHeight = Console.WindowHeight;
int position = 0;

var randomizer = new Random();

while (!Console.KeyAvailable)
{
    position++;
    Thread.Sleep(500);
    Console.CursorVisible = false;
    Console.SetCursorPosition(randomizer.Next(windowWidth), position);
    Console.WriteLine('*');
    Console.WriteLine();
    Console.WriteLine();

}
