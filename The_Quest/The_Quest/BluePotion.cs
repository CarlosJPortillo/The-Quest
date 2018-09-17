using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class BluePotion : Weapon
    {
        public BluePotion(Game game, Point location) :base(game, location) { healthValue = 1000; }
        public override string Name { get { return "Blue Potion"; } }
        private int healthValue;


        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(healthValue, random);
            game.Player.EquippedWeapon = null;

        }



    }
}
