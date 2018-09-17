using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location) : base(game, location) { damageValue = 6; radius = 30; }
        public override string Name { get { return "Mace"; } }
        public override void Attack(Direction direction, Random random)
        {
            //attack in all four directions
            foreach(Enemy enemy in game.enemies)
            {
                DamageEnemy(radius, damageValue, random, enemy);
            }
            
        }
    }
}
