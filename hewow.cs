using System;

class Program
{
    static int maple = 8;
    static string[][] map;

    static void Main()
    {
        map = new string[maple][];


	}
		
	
	
	
	static void Mapa()
	{
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
static void read(int x, int y){	
	while (true)
	{
bool press = false 
		
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
    x = x-1;
		press = true
        break;
    case ConsoleKey.S:
    case ConsoleKey.DownArrow:
	x++;
		press = true
		break;
    case ConsoleKey.A:
    case ConsoleKey.LeftArrow:
    y = y-1;
		press = true
		break;
    case ConsoleKey.D:
    case ConsoleKey.RightArrow:
	y ++;
		press = true
        break;
}
if (press)
{
Player(x, y)
MapPrint()
}

	}

    
    

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
