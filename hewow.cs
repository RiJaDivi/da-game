using System;

class Program
{
    static int maple = 8;
    static string[][] map;

    static void Main()
    {
        map = new string[maple][];

        bool esc = false;
        int x = 4;
        int y = 4;
	Mapa();
	Read(x, y, esc);	

	}
			
	
	static void Mapa()
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
		}
		
		
static void Read(int x, int y, bool esc){	
	while (true)
	{
bool press = false; 
		
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
	if (x != 0){x = x-1;}
		press = true;
        break;
    case ConsoleKey.S:
    case ConsoleKey.DownArrow:
	if (x != maple -1){x++;}
		press = true;
		break;
    case ConsoleKey.A:
    case ConsoleKey.LeftArrow:
    if ( y != 0){y = y-1;}
		press = true;
		break;
    case ConsoleKey.D:
    case ConsoleKey.RightArrow:	
if (y != maple - 1){y++;}
		press = true;
        break;
}
if (press)
{
Console.Clear();
Mapa();
Player(x, y);
MapPrint();
}
}
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
