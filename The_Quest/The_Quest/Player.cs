using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Player : Mover
    {
        private Weapon equippedWeapon = null;
        public Weapon EquippedWeapon { get { return this.equippedWeapon; } set { equippedWeapon = value; } }
        private int hitPoints;
        public int HitPoints {get { return this.hitPoints; } }

        //player holds multiple weapons in inventory, but only 1 is allowed to be equipped
        private List<Weapon> inventory = new List<Weapon>();
        public List<Weapon> Inventory { get { return this.inventory; } }
        public List<String> Weapons
        {
            get
            {
                List<String> names = new List<String>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }

        }
        public Player(Game game, Point location) :base(game, location)
        {
            hitPoints = 10; // player constructor sets it's hitPoints to 10 and then calls teh base class constructor
        }
        //This method is for when player get's hit by an enemy. Random damage is assigned
        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage+1);
        }
        //This method is for when player uses a potion, their health is restored by random value
        public void IncreaseHealth(int health, Random random)
        {
            hitPoints += random.Next(1, health+1);
        }
        //The equip method tells the player to equip one of his weapons. The Game object call this method when one of the
        //inventory icons is clicked
        public void Equip(string weaponName)
        {
            foreach(Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon; //only weapon can be equipped 
            }
        }
        //Moves the player in 4 directions determined by button clicked
        public void Move(Direction direction)
        {
            //determines how far you need to be grab weapon
            int grabDistance = 30;
            base.location = Move(direction, game.Boundaries);
            // checks to see if weapon is next to player 2 spaces away, and if so pick up weapon and add it to their inventory
               
            if (!game.weaponInRoom.PickedUp)
            {
                if(Nearby(game.weaponInRoom.Location, grabDistance))
                {
                    inventory.Add(game.weaponInRoom);
                    game.weaponInRoom.PickedUp = true;
                }
                if (inventory.Count() == 1)
                    Equip(game.weaponInRoom.Name);
 
            }
        }
        public void Attack(Direction direction, Random random)
        {
            if(equippedWeapon != null)
            {
                equippedWeapon.Attack(direction, random);
            }
        }





    }
}
