using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.PrintProperties(player);
            Console.WriteLine("________________________________");
            player.AddXP(100); //To lvl 2
            player.PrintProperties(player);
            player.AddXP(100); //To lvl 3
            player.PrintProperties(player);
            player.AddXP(150); //To lvl 4
            player.PrintProperties(player);
            player.AddXP(300); //To lvl 5
            player.PrintProperties(player);
            player.AddXP(750); //To lvl 6
            player.PrintProperties(player);
            Console.WriteLine("________________________________");
            Console.WriteLine("________________________________");
            Enemy enemy = new Enemy();
            if(player.FightEnemy(enemy))
            {
                Console.WriteLine("You won the fight!");
                player.AddXP(enemy.xp);
                player.PrintProperties(player);
            }
            else
            {
                Console.WriteLine("You died.");
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("________________________________");

            Console.ReadKey();
        }
    }

    public class Player
    {

        public double health { get; set; }
        public double damage { get; set; }

        public int level { get; set; }
        public double xpMax { get; set; }
        public double currentXP { get; set; }
        public double xpLeft { get; set; }

            //Prints outs the fields in the Player class.
        public void PrintProperties(Player _player)
        {
            double xp = GetXpLeft();
            string properties = String.Format("Current player has " + _player.currentXP + " XP. Is level " + _player.level + ". Required for next level " + xp);
            Console.WriteLine(properties);
        }
            //Constructor that fills in 3 fields
        public Player()
        {
            level = 1;
            xpMax = 100;
            currentXP = 0;
            health = 100;
            damage = 10;
        }
        
            //Adds XP to playerobject when called, taking in the amount of XP gained as parameter.
            //After adding the XP, if the currentXP exceeds/equal to the max XP call method LevelUp();
        public void AddXP(double _xp)
        {
            currentXP += _xp;
            if (currentXP >= xpMax)
            {
                LevelUp(1);
            }
        }

            //Method for checking the amount of xp left for the next level.
        public double GetXpLeft()
        {
            xpLeft = xpMax - currentXP;
            return xpLeft;
        }

            //Private method that is called in the AddXP method only.
            //Sets the xpMax field to increase on every level gained.
        private void LevelUp(int _levels)
        {
            level += _levels;
            currentXP = 0;
            xpMax = xpMax * (level * 0.5);
        }

        public bool FightEnemy(Enemy _enemy)
        {
            do
            {
                this.health -= _enemy.damage;
                _enemy.health -= this.damage;
            }
            while (_enemy.health > 0 && this.health > 0);
            if (this.health >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Enemy
    {
        public double health { get; set; }
        public double damage { get; set; }
        public double xp { get; set; }

        public Enemy()
        {
            health = 50;
            damage = 5;
            xp = 10;
        }
        
    }
}
