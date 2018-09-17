using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location) :base(game, location, 6) { damageValue = 2; }
        //bat moves randomly 50% of the time, the other 50% it moves towards the player
        public override void Move(Random random)
        {
            Direction direction = Direction.Up;
            //get a random a number, where half chance it moves towards the player and the other it moves randomly
            int decision = random.Next(1, 9);
            if(decision <= 4)
            {
                switch (decision)
                {
                    case 1:
                        direction = Direction.Up;
                        break;
                    case 2:
                        direction = Direction.Down;
                        break;
                    case 3:
                        direction = Direction.Left;
                        break;
                    case 4:
                        direction = Direction.Right;
                        break;
                }
                base.location = Move(direction, game.Boundaries);

            }
            else
            {
                direction = FindPlayerDirection(game.PlayerLocation);
                Move(direction, game.Boundaries);
            }
            //checks if near player and if true, then hit's the player with damage
            if (NearPlayer())
            {
                game.Player.Hit(damageValue, random);
            }
        }
    }
}
