using System;

class Program
{
    static int maple = 8;
    static string[][] map;

    static void Main()
    {
        map = new string[maple][];

        for (int i = 0; i < maple; i++)
        {
            map[i] = new string[maple];
            for (int j = 0; j < maple; j++)
            {
                map[i][j] = ".";
            }
        }
	bool esc = false;
        int x = 6;
        int y = 0;
	while (true)
	{
if (esc)
{
	break;
}
var key = Console.ReadKey(false);
switch (key.Key)
{
	
    case ConsoleKey.Escape:
	Console.WriteLine("Končím");
	esc = true;
        break;

    case ConsoleKey.W:
    case ConsoleKey.UpArrow:
        Console.WriteLine("Nahoru");
        break;
    case ConsoleKey.S:
    case ConsoleKey.DownArrow:
        Console.WriteLine("Dolu");
        break;
    case ConsoleKey.A:
    case ConsoleKey.LeftArrow:
        Console.WriteLine("Leva");
        break;
    case ConsoleKey.D:
    case ConsoleKey.RightArrow:
	y ++;
        break;
}
	}
        Player(x, y);
        MapPrint();

        Console.ReadKey(true);
    }

    static void Player(int x, int y)
    {
        map[x][y] = "P";
    }

    static void MapPrint()
    {
        for (int i = 0; i < maple; i++)
        {
            for (int j = 0; j < maple; j++)
            {
                Console.Write(map[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
