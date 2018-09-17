using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location) { damageValue = 3; radius = 30; }
        public override string Name { get { return "Sword"; } }
        //pass direction, radius, max damage possible, and random 
        public override void Attack(Direction direction, Random random)
        {
            if(direction == Direction.Up)
            {
                foreach(Enemy enemy in game.enemies)
                {
                    //up direction checks if there if there as enemies above, right or left of player
                    if (enemy.Location.Y <= game.Player.Location.Y)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);

                    }
                }
            }
            else if (direction == Direction.Down)
            {
                foreach (Enemy enemy in game.enemies)
                {
                    //down direction checks if there if there as enemies below, right or left of player
                    if (enemy.Location.Y >= game.Player.Location.Y)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
            }
            else if (direction == Direction.Right)
            {
                foreach (Enemy enemy in game.enemies)
                {
                    //right direction checks if there if there as enemies right, above or below of player
                    if (enemy.Location.X >= game.Player.Location.X)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
            }
            else if (direction == Direction.Left)
            {
                foreach (Enemy enemy in game.enemies)
                {
                    //left direction checks if there if there as enemies left, above or below of player
                    if (enemy.Location.X <= game.Player.Location.X)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
            }

        }

    }
}
