using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Game
    {
        public List<Enemy> enemies;
        public Weapon weaponInRoom;

        private Player player; //This game keeps a private Player object. The form only interactrs with this through methods in Game, rather than directly
        public Player Player { get { return this.player; } }
        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public List<string> PlayerWeapons { get { return player.Weapons; } }

        

        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries; //Rectangle object has top, bottom, left, and right fields
        public Rectangle Boundaries { get { return boundaries; } }

        //Game starst out with bounding box for the dungeon, and creates a new Player in the dungeon
        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
        }
        //Movement moves all the units on the board, player and enemies 
        public void Move(Mover.Direction direction, Random random)
        { 

            player.Move(direction);
            foreach (Enemy enemy in enemies)
                enemy.Move(random);
        }
        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }
        public bool CheckPlayerInventory(string weaponName)
        {
            return Player.Weapons.Contains(weaponName);
        }
        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }
        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }
        //Works just like Move(), except the player will attack and the enemies will get a turn to move
        public void Attack(Mover.Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach(Enemy enemy in enemies)
            {
                enemy.Move(random);
            }
        }
        //in the NewLevel() method, this will allow determine where enemies and weapons can randomly appear
        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left + random.Next(Boundaries.Right / 10 - boundaries.Left / 10) * 10, boundaries.Top +
                random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        } 
        //create levels for game
        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    enemies = new List<Enemy>();
                    enemies.Add(new Bat(this, GetRandomLocation(random)));
                    weaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    enemies = new List<Enemy>();
                    enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    weaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;
                case 3:
                    enemies = new List<Enemy>();
                    enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    weaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;
                case 4:
                    enemies = new List<Enemy>();
                    enemies.Add(new Bat(this, GetRandomLocation(random)));
                    enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    if (CheckPlayerInventory("Blue Potion"))
                        weaponInRoom = new Bow(this, GetRandomLocation(random));
                    else
                        weaponInRoom = new BluePotion(this, GetRandomLocation(random)); 
                    break;
                case 5:
                    enemies = new List<Enemy>();
                    enemies.Add(new Bat(this, GetRandomLocation(random)));
                    enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    weaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;
                case 6:
                    enemies = new List<Enemy>();
                    enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    weaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;
                case 7:
                    enemies = new List<Enemy>();
                    enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    enemies.Add(new Bat(this, GetRandomLocation(random)));
                    if (CheckPlayerInventory("Red Potion"))
                        weaponInRoom = new Mace(this, GetRandomLocation(random));
                    else
                        weaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;
                case 8:
                    break;
                
            }
        }

    }
}
