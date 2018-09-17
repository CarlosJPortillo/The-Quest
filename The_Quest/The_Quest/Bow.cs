using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Bow : Weapon
    {
        public Bow(Game game, Point location) : base(game, location) { damageValue = 1; radius = 70; }
        public override string Name { get { return "Bow"; } }
        public override void Attack(Direction direction, Random random)
        {
            foreach(Enemy enemy in game.enemies)
            {
                //UP
                if (direction == Direction.Up)
                {

                    if (enemy.Location.Y < game.Player.Location.Y && Math.Abs(enemy.Location.X - game.Player.Location.X) <=20)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
                //Down
                else if (direction == Direction.Down)
                {
                    if (enemy.Location.Y > game.Player.Location.Y && Math.Abs(enemy.Location.X - game.Player.Location.X) <=20)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
                //Right
                else if (direction == Direction.Right)
                {
                    if (enemy.Location.X > game.Player.Location.X && Math.Abs(enemy.Location.Y - game.Player.Location.Y) <= 20)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
                //Left
                else if (direction == Direction.Left)
                {
                    if (enemy.Location.X < game.Player.Location.X && Math.Abs(enemy.Location.Y - game.Player.Location.Y) <=20)
                    {
                        DamageEnemy(radius, damageValue, random, enemy);
                    }
                }
                }
            }
        }
    }

