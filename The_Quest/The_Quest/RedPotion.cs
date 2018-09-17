using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class RedPotion : Weapon
    {
        public RedPotion(Game game, Point location) : base(game, location){ healthvalue = 10; }
        public override string Name { get { return "Red Potion"; } }
        public int healthvalue;

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(healthvalue, random);
        }

    }
}
