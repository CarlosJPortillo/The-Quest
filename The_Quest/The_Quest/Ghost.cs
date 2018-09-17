using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location) : base(game, location, 6) { damageValue = 3; }
        //ghost only moves 1/3 of the time
        public override void Move(Random random)
        {
            Direction direction;
            //get a random a number, where 1/3 chance it moves towrads the enemy, the 2/3 chance it stands still
            int decision = random.Next(1, 4);
            if (decision == 1)
            {
                direction = FindPlayerDirection(game.PlayerLocation);
                base.location = Move(direction, game.Boundaries);
            }
            else
            {

            }
            if(NearPlayer())
            {
                game.Player.Hit(damageValue, random);
            }
        }
    }
}
