using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    abstract class Enemy : Mover
    {
        private const int NearPlayerDistance = 25;
        private int hitPoints;
        public int HitPoints { get { return this.hitPoints; } }
        public bool Dead { get { if (hitPoints <= 0) return true; else return false; } }
        protected int damageValue;

        public Enemy(Game game, Point location, int hitPoints) :base(game, location)
        {
            this.hitPoints = hitPoints;
        }
        public abstract void Move(Random random);
        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage+1);
        }
        //The enemy class inherited the Nearby() method from Mover, which it can use to find out whether it's near the player
        protected bool NearPlayer()
        {
            return (Nearby(game.PlayerLocation, NearPlayerDistance));
        }
        //If you pass the FindPlayerDirection the player's location, it will use the base class's location field to figure out where 
        //the player is in reiation to the enemy and return a direction 
        protected Direction FindPlayerDirection(Point playerloaction)
        {
            Direction directionToMove;
            if (playerloaction.X > this.location.X + 10)
                directionToMove = Direction.Right;
            else if (playerloaction.X < this.location.X - 10)
                directionToMove = Direction.Left;
            else if (playerloaction.Y < this.location.Y - 10)
                directionToMove = Direction.Up;
            else
                directionToMove = Direction.Down;

            return directionToMove;
        }

    }
}
