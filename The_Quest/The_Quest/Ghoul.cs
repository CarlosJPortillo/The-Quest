using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location) : base(game, location, 6) { damageValue = 4; }
        //ghoul only moves 2/3 of the time
        public override void Move(Random random)
        {
            Direction direction;
            //get a random a number, where 2/3 chance it moves towrads the enemy, the 1/3 chance it stands still
            int decision = random.Next(1, 4);
            if (decision <= 2)
            {
                direction = FindPlayerDirection(game.PlayerLocation);
                base.location = Move(direction, game.Boundaries);
            }
            else
            {

            }
            if (NearPlayer())
            {
                game.Player.Hit(damageValue, random);
            }
        }
    }
}
