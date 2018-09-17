using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    abstract class Mover
    {
        protected const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;
        public enum Direction { Up, Down, Left, Right };

        //takes in game object and a current location
        public Mover (Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }
        //checks a point against this object's current location. If they're within distance of each other, then it returns true, otherwise false is returned
        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(this.location.X - locationToCheck.X) < distance && Math.Abs(this.location.Y - locationToCheck.Y) < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //The move method tries to move one step in one of the four directions if it can. If it hits a boundary, it returns the original Point
        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            switch(direction)
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
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                        newLocation.X += MoveInterval;
                    break;
                default:
                    break;
            }
            return newLocation;
        }

    }
}
