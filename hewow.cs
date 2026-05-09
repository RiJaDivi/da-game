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
public static int zivot = 3;
public static int startposx;
public static int PlaUtok = 1;
public static int monSl = 0;
public static int lvl = 1;
public static int stoner = 1;
public static int ability;
public static int block = 0;
public static int charge = 0;
public static double modifi = 1;
public static bool weagiver = false;
public static bool konec = false;
public static bool esc = false;
public static List<Monsters> monsters = new List<Monsters>();


static void Main()
    {
	Console.Clear();
	AskRole();
	for (int i = 0; i < 3; i++){
	Compli();	
	if (konec || esc){break;}
	}
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
		
		
static void Read(){	
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
	if (x != 0 && MR(x - 1, y)){x = x-1;}
	else if (!MonFul(x - 1, y)){Utok(x - 1, y);}
		press = true;
        break;
    case ConsoleKey.S:
    case ConsoleKey.DownArrow:
	if (x != maple -1 && MR(x + 1, y)){x++;}
	else if (!MonFul(x + 1, y)){Utok(x + 1, y);}
		press = true;
		break;
    case ConsoleKey.A:
    case ConsoleKey.LeftArrow:
    if ( y != 0 && MR(x, y - 1)){y = y-1;}
	else if (!MonFul(x, y - 1)){Utok(x, y - 1);}
		press = true;
		break;
    case ConsoleKey.D:
    case ConsoleKey.RightArrow:	
if (y != maple - 1 && MR(x, y + 1)){y++;}
else  if (!MonFul(x, y + 1)){Utok(x, y + 1);}
		press = true;
        break;
    case ConsoleKey.E:
	if (charge == 2){
	Power();
	press = true;
	charge = 0;
	}
	break;
     case ConsoleKey.Spacebar:
	press = true;
	break;
}
if (press)
{
Mapa();
Console.Clear();
Player();
MonsterMovin();
MapPrint();
ZUkaz();
PlayEnd();
if (konec || LevelUp()){
break;
	   }
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
	kamenx = new List<int>();
	kameny = new List<int>();
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
public int Stoned;
public bool Weaknes;
public Monsters(int zivot, int utok, char skin, int posx, int posy){
Zivot = zivot;
Utok = utok;
Skin = skin;
Posx = posx;
Posy = posy;
Stoned = 0;
Weaknes = false;
}
public abstract void Move();

}
public class Goblin : Monsters{
public Goblin(int zivot, int utok, int posx, int posy) : base(zivot, utok, 'G', posx, posy){}
public override void Move()
	{
	SimpleMove(ref Posx, ref Posy, Utok, ref Weaknes);
	}
}


public class Slime : Monsters
{
public int Velikost;
public Slime(int zivot, int velikost, int posx, int posy) : base(zivot, velikost, 'S', posx, posy)
	{

Velikost = velikost;
Utok = (int)Math.Round(velikost * modifi);
Skin = 'S';
	}
public override void Move()
	{
SimpleMove(ref Posx, ref Posy, Utok, ref Weaknes);
	}
}
public class Zombie : Monsters{
public bool Reborn;

public Zombie(int zivot, int utok, int posx, int posy) : base(zivot, utok, 'Z', posx, posy)
{
Reborn = true;
}
public override void Move(){
SimpleMove(ref Posx,ref Posy, Utok, ref Weaknes);

}
}
enum Role{
Berserk,
Knight,
Warior
}
static void SetRole(Role role)
{
switch(role){
	case Role.Berserk:
		PlaUtok = 3;
		zivot = 2;
		stoner = 2;
		ability = 1;
		break;
	case Role.Knight:
		PlaUtok = 1;
		zivot = 5;
		weagiver = true;
		ability = 2;
		break;
	case Role.Warior:
		PlaUtok = 2;
		zivot = 3;
		ability = 3;
		break;

	  }
}
static void AskRole()
{
Console.WriteLine("Vyber si za koho chceš bojovat stiskem čísel");
Console.WriteLine(" 1 : Berserk				2 : Knight			3 : Warior");
var key = Console.ReadKey(false);
switch(key.KeyChar)
{
	case '1':
	case '+':
	SetRole(Role.Berserk);
	break;
	case '2':
	case 'ě':
        SetRole(Role.Knight);
        break;
	case '3':
	case 'č':
	SetRole(Role.Warior);
	break;
}
}
static void SimpleMove(ref int Posx, ref int Posy, int atk, ref bool weak){
if (Math.Abs(x - Posx) > Math.Abs(y - Posy)){
	if (x - Posx > 0)
	{
	if (MR(Posx + 1, Posy) && PlayHere(Posx + 1, Posy))
	{
	Posx ++;
	}
	else if (!PlayHere(Posx + 1, Posy)){
		GetIn(atk, weak);
		
	}
	}
	
	else if (x - Posx < 0)
	{ if (MR(Posx - 1, Posy) && PlayHere(Posx - 1, Posy))
	{ 
	Posx --;
	}
	else if (!PlayHere(Posx - 1, Posy))
		{
		GetIn(atk, weak);
		}		     
	
	}
						}
else{
        if (y - Posy > 0) 
        {
	if (MR(Posx, Posy + 1) && PlayHere(Posx, Posy + 1)) {
        Posy ++;}
	else if (!PlayHere(Posx, Posy + 1))
		{
		GetIn(atk, weak);
		}
        }
        else if (y - Posy < 0)
	{if (MR(Posx, Posy - 1) && PlayHere(Posx, Posy - 1))
        {
        Posy --;
        }
	else if (!PlayHere(Posx, Posy - 1))
		{
		GetIn(atk, weak);
		}
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
			monsters.Add(new Goblin((int)Math.Round(2 * modifi), (int)Math.Round(2 * modifi), posx, posy));
			break;
		case 1:
                        monsters.Add(new Zombie((int)Math.Round(3 * modifi), (int)Math.Round(1 * modifi), posx, posy));
                        break;
		case 2:
			monsters.Add(new Slime((int)Math.Round(6 * modifi), 2, posx, posy));
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
static void MonsterMovin(){
foreach (var m in monsters){
ZombiePr(m);
if (m.Stoned == 0){
m.Move();
			    }
else {
m.Stoned --;
      }
			   }				
			  }
static bool PlayHere(int posx, int posy){
if (posx == x && posy == y){
return false;
}
else{
return true;
}
}

static bool MR(int posx, int posy)
{
if (Hitrock(posx, posy) && MonFul(posx, posy))
{
return true;
}
else
{
return false;
}
}

static void ZUkaz()
{
Console.WriteLine("                  ");
for (int i = 0; i < zivot; i++)
{
Console.Write(" o");
}
Console.WriteLine("");
Console.WriteLine($"Aktuální lvl: {lvl}                  {monSl}");
if (charge == 2)
{Console.WriteLine("	Můžeš použít ability (e)");}


}

static void Utok(int posx,int posy)
{
for(int i = monsters.Count - 1; i >= 0; i--){
var m = monsters[i];

if ((posx, posy) == (m.Posx, m.Posy)){
m.Zivot = m.Zivot - PlaUtok;
if (weagiver){m.Weaknes = true; m.Skin = char.ToLower(m.Skin);}
m.Stoned = stoner;
Check();
if (posx != x) {
		if (x > posx && MR(posx - 1, posy) && posx - 1 >= 0){		
			m.Posx --;
		    	     }
		else if (MR(posx + 1, posy) && MR(posx - 1, posy) && posx + 1 < maple){
		m.Posx ++;
		     }
		}
else{
                if (y > posy && MR(posx, posy - 1) && posy - 1 >= 0){
		m.Posy --;
		}
                else if(MR(posx, posy + 1)&& MR(posx, posy - 1) && posy + 1 < maple){ 
                m.Posy ++;
                }
     }
				     }
			  }
}
static void Check(){
for (int i = monsters.Count - 1; i >= 0; i--)
{

    if (monsters[i].Zivot <= 0)
    {

	if (monsters[i] is Zombie z){
	if (z.Reborn){ 
	z.Stoned = 3;
        z.Skin = 'c';
        z.Weaknes = false;
        z.Reborn = false;
	z.Zivot = (int)Math.Round(3 * modifi);
	continue;
			}
			}
	Split(monsters[i]);
	PuThing(monsters[i].Posx, monsters[i].Posy, '.');
        monsters.RemoveAt(i);
        monSl ++;
	if (charge != 2){
	charge ++;
			}
    }
}	
		    }
static void PlayEnd()
{
if (zivot < 1){
konec = true;
	       }
}
static bool LevelUp(){
if (monsters.Count == 0)
{
return true;
}
else 
{
return false;
}
		      }
static void ZombiePr(Monsters m){
if (m is Zombie z && !z.Reborn && z.Stoned == 0){
        m.Skin = m.Weaknes ? 'z' : 'Z';
			       }
		    		}
static void Split(Monsters m)
{
if (m is Slime s && s.Velikost > 1)
{
var (posx, posy) = SlimeTrics(s);
if (posx != -1)
{monsters.Add(new Slime((int)Math.Round(3 * Math.Pow(2, s.Velikost - 2) * modifi), s.Velikost - 1, posx, posy));}
(posx, posy) = SlimeTrics(s);
if (posx != -1){
monsters.Add(new Slime((int)Math.Round(3 * Math.Pow(2, s.Velikost - 2) * modifi), s.Velikost - 1, posx, posy));
		}
}
}


static (int posx,int posy) SlimeTrics(Monsters s){
		if (MR(s.Posx, s.Posy + 1) && PlayHere(s.Posx, s.Posy + 1) && s.Posy < maple){return (s.Posx, s.Posy + 1);}
                if (MR(s.Posx, s.Posy - 1) && PlayHere(s.Posx, s.Posy - 1) && s.Posy > 0){return (s.Posx, s.Posy - 1);}
                if (MR(s.Posx + 1, s.Posy) && PlayHere(s.Posx + 1, s.Posy) && s.Posx < maple){return (s.Posx + 1, s.Posy);}
                if (MR(s.Posx - 1, s.Posy) && PlayHere(s.Posx - 1, s.Posy) && s.Posx > 0){return (s.Posx - 1, s.Posy);}
		return (-1, -1);
	  }
static void Power()
{
switch(ability){
	case 1:
	BlowUp();	
	break;
	case 2:
	block = 1;
	break;
	case 3:
	Stunin();
	break;
		}
}

static void BlowUp(){
Utok(x + 1, y);
Utok(x - 1, y);
Utok(x, y + 1);
Utok(x, y - 1);
			}
static void Stunin(){
foreach (var m in monsters){
m.Stoned = 3;
			}
		     }

static void GetIn(int utok, bool weak){
if (block == 0){
if (!weak){
zivot -= utok;
	   }
else{
zivot = zivot - (int)(Math.Round(utok * 0.5));
    }
	    }
else{
block --;
    }
		     }


static void Compli()
{
        Console.Clear();   
        map = new char[maple][];
        int kamen = 8;
        Mapa();
	x = 4;
	y = 4;
        Rocks(kamen);
        MonsterCreate(3);
	Player();
	MapPrint();
	ZUkaz();
        Read();
        if (konec && monSl > 1 && monSl < 5){Console.Clear(); Console.WriteLine("Zemřel jsi."); Console.WriteLine($"Zabil jsi {monSl} nepřátele");}
        else if (konec && (monSl >= 5 ||  monSl == 0)){Console.Clear(); Console.WriteLine("Zemřel jsi."); Console.WriteLine($"Zabil jsi {monSl} nepřátel");}
	else if (konec && monSl == 1){Console.Clear(); Console.WriteLine("Zemřel jsi."); Console.WriteLine($"Zabil jsi {monSl} nepřítele");}
	if (LevelUp()) {lvl ++; Console.Clear();Console.WriteLine("Gratuluji, porazil jsi vsechny monstra, a vzal jsi si princeznu nebo tak něco");}
}

}
