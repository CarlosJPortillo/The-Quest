using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    abstract class Weapon : Mover
    {
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
        protected int damageValue;
        protected int radius = 0;

        //constructors calls Mover's base constructor(which sets the game and location fields) and it sets picked up to false since it 
        //never gets picked up right away when it gets initialized
        public Weapon(Game game, Point location) :base(game, location)
        {
            pickedUp = false;
        }
        public void PickUpWeapon() { pickedUp = true; }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);
        //checks if enemy is within raidus of weapon's range, overloaded method from Mover class with three parameters
        public bool Nearby(Point locationToCheck, Point currentLocation, int radius)
        {
            if (Math.Abs(currentLocation.X - locationToCheck.X) <= radius && Math.Abs(currentLocation.Y - locationToCheck.Y) <= radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //tries to move into new postion, overloaded method from Mover class with three parameters
        public Point Move(Direction direction, Point currentLocation, Rectangle boundaries)
        {
            Point newLocation = currentLocation;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.Y + MoveInterval >= boundaries.Right)
                        newLocation.Y += MoveInterval;
                    break;
                default:
                    break;
            }
            return newLocation;
        }

        protected bool DamageEnemy(int radius, int damage, Random random, Enemy enemy)
        {
            Point target = game.PlayerLocation;
            int distance = 10;
            while(distance <= radius)
            {
                if (Nearby(enemy.Location, target, radius))
                {
                    enemy.Hit(damage, random);
                    return true;
                }
                distance = distance + 10;
            }
            return false;
        }
    }
}
