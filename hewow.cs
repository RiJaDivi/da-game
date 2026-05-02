using System;
using System.Security.Cryptography;
class Program
{
    static int maple = 8;
    static string[][] map;
public static List<int> kameny = new List<int>{};
public static List<int> kamenx = new List<int>{};


static void Main()
    {
        map = new string[maple][];
	startposx = 4
        bool esc = false;
        int x = 4;
        int y = 4;
	int kamen = 8;
	Rocks(kamen);
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
	if (x != 0 && Hitrock(x - 1, y)){x = x-1;}
		press = true;
        break;
    case ConsoleKey.S:
    case ConsoleKey.DownArrow:
	if (x != maple -1 && Hitrock(x + 1, y)){x++;}
		press = true;
		break;
    case ConsoleKey.A:
    case ConsoleKey.LeftArrow:
    if ( y != 0 && Hitrock(x, y - 1)){y = y-1;}
		press = true;
		break;
    case ConsoleKey.D:
    case ConsoleKey.RightArrow:	
if (y != maple - 1 && Hitrock(x, y + 1)){y++;}
		press = true;
        break;
}
if (press)
{
Mapa();
Console.Clear();
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
	Renderock();
        for (int i = 0; i < maple; i++)
        {
            for (int j = 0; j < maple; j++)
            {
                Console.Write(map[i][j] + " ");
            }
            Console.WriteLine();
      }
    }
	static void Rocks(int pocet)
{
        for (int i = 0; i < pocet; i++)
{	
var rngNum1 = RandomNumberGenerator.GetInt32(maple);
var rngNum2 = RandomNumberGenerator.GetInt32(maple);
if (rngNum1 == maple // 2 && rngNum2 == maple // 2){
skip;
}
Storock(rngNum1, rngNum2);
}}

static void Renderock(){
for (int i = 0; i < kameny.Count; i++){
PutRock(kamenx[i], kameny[i]);
}
}

 
	static void PutRock(int x, int y)
{
map[x][y] = "R";
}

static void Storock(int rnd1, int rnd2)
{
kameny.Add(rnd1);
kamenx.Add(rnd2);
}
static bool Hitrock(int x, int y)
{
for (int i = 0; i < kameny.Count; i++){
if (kameny[i] == y && kamenx[i] == x){
return false;
}

}
return true;
}

public class Monsters{
public int Zivot;
public int Utok;
public char Skin;
public Monsters(int zivot, int utok, char skin){
Zivot = zivot;
Utok = utok;
Skin = skin;
}
public abstract void Move(){
}
}
public class Goblin : Monsters{
pubic Goblin(int zivot, int utok) : base(zivot, utok, 'G'){

}
}


public class Slime : Monsters{
public int Velikost;
public Slime(int zivot, int utok, int velikost) : base(zivot, utok, 'S'){
Velikost = velikost;
Skin = 'S';
}
}
public class Zombie : Monsters{
bool Reborn;

public Zombie(int zivot, int utok) : base(zivot, utok, 'Z')
{
Reborn = true;

}
}

}
