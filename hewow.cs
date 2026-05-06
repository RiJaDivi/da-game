using System;
using System.Security.Cryptography;
class Program
{
    static int maple = 8;
    static char[][] map;
public static List<int> kameny = new List<int>{};
public static List<int> kamenx = new List<int>{};
public static int x = 4;
public static int y = 4;
public static int startposx;
public static List<Monsters> monsters = new List<Monsters>();

static void Main()
    {
		
        map = new char[maple][];
        bool esc = false;
	int kamen = 8;
	Mapa();
	Rocks(kamen);
	MonsterCreate(3);
	Read(esc);
	MonsteRead();	
	}
			
	
	static void Mapa()
	{
		map = new char[maple][];
        for (int i = 0; i < maple; i++)
        {
            map[i] = new char[maple];
            for (int j = 0; j < maple; j++)
            {
                map[i][j] = '.';
            }

		}
		}
		
		
static void Read(bool esc){	
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
	Console.WriteLine(" končím");
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
Player();
MapPrint();
}
 }
  }
    static void Player()
    {
        map[x][y] = 'P';
    }

    static void MapPrint()
    {
	Renderock();
	MonsteRender();
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
if (rngNum1 == startposx && rngNum2 == startposx){
continue;
}
Storock(rngNum1, rngNum2);
}}

static void Renderock(){
for (int i = 0; i < kameny.Count; i++){
PuThing(kamenx[i], kameny[i], 'R');
}
}

 
static void PuThing(int m, int n, char R)
{
map[m][n] = R;
}

static void Storock(int rnd1, int rnd2)
{
kameny.Add(rnd1);
kamenx.Add(rnd2);
}
static bool Hitrock(int m, int n)
{
for (int i = 0; i < kameny.Count; i++){
if (kameny[i] == n && kamenx[i] == m){
return false;
}

}
return true;
}

public abstract class Monsters{
public int Zivot;
public int Utok;
public char Skin;
public int Posx;
public int Posy;
public Monsters(int zivot, int utok, char skin, int posx, int posy){
Zivot = zivot;
Utok = utok;
Skin = skin;
Posx = posx;
Posy = posy;
}
public abstract void Move();

}
public class Goblin : Monsters{
public Goblin(int zivot, int utok, int posx, int posy) : base(zivot, utok, 'G', posx, posy){}
public override void Move()
	{
	SimpleMove(ref Posx, ref Posy);
	}
}


public class Slime : Monsters
{
public int Velikost;
public Slime(int zivot, int utok, int velikost, int posx, int posy) : base(zivot, utok, 'S', posx, posy)
	{
Velikost = velikost;
Skin = 'S';
	}
public override void Move()
	{
SimpleMove(ref Posx, ref Posy);
	}
}
public class Zombie : Monsters{
bool Reborn;

public Zombie(int zivot, int utok, int posx, int posy) : base(zivot, utok, 'Z', posx, posy)
{
Reborn = true;
}
public override void Move(){
SimpleMove(ref Posx,ref Posy );

}
}

static void SimpleMove(ref int Posx, ref int Posy){
if (Math.Abs(x - Posx) > Math.Abs(y - Posy)){
	if (x - Posx > 0)
	{
	Posx ++;
	}
	else
	{
	Posx --;
	}
}
else{
        if (y - Posy > 0) 
        {
        Posy ++;
        }
        else 
        { 
        Posy --;
        }
    }

}
static void MonsterCreate(int poc){
for (int i = 0; i < poc; i++)
 {
   var (posx, posy) = Moncontr();
   var rngNum1 = RandomNumberGenerator.GetInt32(3);
   if (posx == -1){break;}
    switch(rngNum1){
		case 0:
			monsters.Add(new Goblin(1, 2, posx, posy));
			break;
		case 1:
                        monsters.Add(new Zombie(2, 1, posx, posy));
                        break;
		case 2:
			monsters.Add(new Slime(2, 1, 2, posx, posy));
			break;
	   }
 }
				 }
static int Randomize(){
int r = RandomNumberGenerator.GetInt32(6); // 0–5

if (r > 2)
{
r += 2;
}
return r;
			}
static (int posx, int posy) Moncontr(){
for(int i = 0; i < maple * maple; i++){
int posx = Randomize();
int posy = Randomize();
if (Hitrock(posx, posy) && MonFul(posx, posy))
{return (posx, posy);
}
		   }
Console.WriteLine("Nebude plný počet nepřátel");
return (-1, -1);
		    			}
static void MonsteRead(){
foreach (var m in monsters){
    Console.WriteLine($"HP: {m.Zivot}, ATK: {m.Utok}, X: {m.Posx}, Y: {m.Posy}");
			   }			
			}
static bool MonFul(int m, int n){
foreach (var i in monsters){
 if(i.Posx == m && i.Posy == n){
	return false;
				}
			}
return true;
				}
			
static void MonsteRender()
{
foreach (var m in monsters){
if (m == null) {continue;}
PuThing(m.Posx, m.Posy, m.Skin);
			}
		       }
}
