using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Quest
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();
        //reference variable that points to whatever box corresponds to the weapon on level
        private PictureBox weaponInRoomBox = null;
        //variable to see if potion was used this turn, player can only use a potion once before it disappears
        private bool potionUsed;
        private List<PictureBox> inventoryBoxes = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddInventoryBoxes();
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }
      
        //Inventory picture box handlers 
        private void swordBox_Click(object sender, EventArgs e)
        {
            if (game.Player.Weapons.Contains("Sword"))
            {
                ShowButtons();
                game.Player.Equip("Sword");
                Up.Text = "Up";
                swordBox.BackColor = System.Drawing.Color.Red;
                MakeBoxesTransparent(swordBox.Name);
            }
        }

        private void redPotionBox_Click(object sender, EventArgs e)
        {
            if (game.Player.Weapons.Contains("Red Potion"))
            {
                game.Player.Equip("Red Potion");
                HideButtons();
                Up.Text = "Drink";
                redPotionBox.BackColor = System.Drawing.Color.Red;
                MakeBoxesTransparent(redPotionBox.Name);
            }
        }

        private void maceaBox_Click(object sender, EventArgs e)
        {
            if (game.Player.Weapons.Contains("Mace"))
            {
                ShowButtons();
                game.Player.Equip("Mace");
                Up.Text = "Up";
                maceaBox.BackColor = System.Drawing.Color.Red;
                MakeBoxesTransparent(maceaBox.Name);
            }
        }

        private void quiverBox_Click(object sender, EventArgs e)
        {
            if (game.Player.Weapons.Contains("Bow"))
            {
                ShowButtons();
                game.Player.Equip("Bow");
                Up.Text = "Up";
                quiverBox.BackColor = System.Drawing.Color.Red;
                MakeBoxesTransparent(quiverBox.Name);
            }
        }

        private void bluePotionBox_Click(object sender, EventArgs e)
        {
            if (game.Player.Weapons.Contains("Blue Potion"))
            {
                game.Player.Equip("Blue Potion");
                HideButtons();
                Up.Text = "Drink";
                bluePotionBox.BackColor = System.Drawing.Color.Red;
                MakeBoxesTransparent(bluePotionBox.Name);

            }
        }
        //Attack Button Event Handlers
        private void Right_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Right, random);
            UpdateCharacters();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Up, random);
            UpdateCharacters();
            //if you drink from the potion, the picture box should be invisible
            if(Up.Text == "Drink")
            {
                bluePotionBox.Visible = false;
                redPotionBox.Visible = false;
                ShowButtons();
                Up.Text = "Up";
                potionUsed = true;
                game.Player.EquippedWeapon = null;
                potionUsed = true;

            }
        }

        private void Left_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Left, random);
            UpdateCharacters();
        }
        private void Down_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Down, random);
            UpdateCharacters();
        }
        //Movement button event handlers
        private void upMove_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Up, random);
            UpdateCharacters();
        }

        private void leftMove_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Left, random);
            UpdateCharacters();
        }

        private void rightMove_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Right, random);
            UpdateCharacters();
        }

        private void downMove_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Down, random);
            UpdateCharacters();
        }

        private void HideButtons()
        {
            Right.Visible = false;
            Left.Visible = false;
            Down.Visible = false;
        }
        private void ShowButtons()
        {
            Right.Visible = true;
            Left.Visible = true;
            Down.Visible = true;
        }
        private void UpdateCharacters()
        {
            ChangeEquippedWeaponBoxColor();
            //set player label hitPoints 
            playerHitPoints.Text = game.PlayerHitPoints.ToString();
            //set picture box's location to player's location 
            dPlayerBox.Location = game.PlayerLocation;
            //show 
            dPlayerBox.Visible = true;
            int enemiesShown = 0;
            //an object that references the weapon in the room's picture box

            ChangeEquippedWeaponBoxColor();

            //loop through enemies in the game 
            foreach (Enemy enemy in game.enemies)
            {
                if (enemy is Bat)
                {
                    dBatBox.Visible = true;
                    
                    dBatBox.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    enemiesShown++;
                }
                if (enemy is Ghost)
                {
                    dGhostBox.Visible = true;
                    dGhostBox.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    enemiesShown++;
                }
                if (enemy is Ghoul)
                {
                    dGhoulBox.Visible = true;
                    dGhoulBox.Location = enemy.Location;
                    ghoutHitPoints.Text = enemy.HitPoints.ToString();
                    enemiesShown++;
                }
            }
                AreEnemiesDead();
            if (!game.weaponInRoom.PickedUp)
            {
                switch (game.weaponInRoom.Name)
                {
                    case "Sword":
                        dSwordBox.Visible = true;
                        dSwordBox.Location = game.weaponInRoom.Location;
                        weaponInRoomBox = dSwordBox;
                        break;
                    case "Bow":
                        dBowBox.Visible = true;
                        dBowBox.Location = game.weaponInRoom.Location;
                        weaponInRoomBox = dBowBox;
                        break;
                    case "Mace":
                        dMaceBox.Visible = true;
                        dMaceBox.Location = game.weaponInRoom.Location;
                        weaponInRoomBox = dMaceBox;
                        break;
                    case "Blue Potion":
                        dBluePotionBox.Visible = true;
                        dBluePotionBox.Location = game.weaponInRoom.Location;
                        weaponInRoomBox = dBluePotionBox;
                        break;
                    case "Red Potion":
                        dRedPotionBox.Visible = true;
                        dRedPotionBox.Location = game.weaponInRoom.Location;
                        weaponInRoomBox = dRedPotionBox;
                        break;
                }
            }
            if (game.weaponInRoom.PickedUp && potionUsed == false)
            {
                weaponInRoomBox.Visible = false;
                if (game.weaponInRoom.Name == "Sword")
                {
                    swordBox.Visible = true;
                }
                else if (game.weaponInRoom.Name == "Bow")
                {
                    quiverBox.Visible = true;
                }
                else if (game.weaponInRoom.Name == "Mace")
                {
                    maceaBox.Visible = true;
                }
                else if (game.weaponInRoom.Name == "Red Potion")
                {
                    redPotionBox.Visible = true;
                }
                else if (game.weaponInRoom.Name == "Blue Potion")
                {
                    bluePotionBox.Visible = true;
                }
            }
            //if your hitpoints reach zero quit game
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You Died");
                Application.Exit();
            }
            //if enemy count drops below 1
            if (game.enemies.Count < 1)
            {
                MessageBox.Show("You killed all enemies on this level");
                //if player didn't pick up weapon on level, set that weapon's box invisible
                weaponInRoomBox.Visible = false;
                game.NewLevel(random);
                potionUsed = false;
                UpdateCharacters();
            }


        }
        //checks to see if enemies are dead and make them invisible and delete them 
        public void AreEnemiesDead()
        {
            //loop through enemies collection 
            for(int i = 0; i < game.enemies.Count; i++)
            {
                if (game.enemies.ElementAt(i) is Bat && game.enemies.ElementAt(i).HitPoints <= 0)
                {
                    game.enemies.Remove(game.enemies.ElementAt(i));
                    dBatBox.Visible = false;
                }
                else if (game.enemies.ElementAt(i) is Ghost && game.enemies.ElementAt(i).HitPoints <= 0)
                {
                    game.enemies.Remove(game.enemies.ElementAt(i));
                    dGhostBox.Visible = false;
                }
                else if (game.enemies.ElementAt(i) is Ghoul && game.enemies.ElementAt(i).HitPoints <= 0)
                {
                    game.enemies.Remove(game.enemies.ElementAt(i));
                    dGhoulBox.Visible = false;
                }
            }
                   
           
        }
        //Used in instance where the player has a weapon equipped to them by default since it's the only item in inventory
        //This method ensures that the equiped weapon inventory box turns red if it gets equipped automatically 
        public void ChangeEquippedWeaponBoxColor()
        {
            if(game.Player.EquippedWeapon != null)
            {
                switch (game.Player.EquippedWeapon.Name)
                {
                    case "Sword":
                        swordBox.BackColor = System.Drawing.Color.Red;
                        break;
                    case "Bow":
                        quiverBox.BackColor = System.Drawing.Color.Red;
                        break;
                    case "Mace":
                        maceaBox.BackColor = System.Drawing.Color.Red;
                        break;
                    case "Red Potion":
                        redPotionBox.BackColor = System.Drawing.Color.Red;
                        break;
                    case "Blue Potion":
                        bluePotionBox.BackColor = System.Drawing.Color.Red;
                        break;

                }
            }
        }
        //Makes list of Inventory Picture Boxes
        public void AddInventoryBoxes()
        {
            inventoryBoxes.Add(swordBox);
            inventoryBoxes.Add(quiverBox);
            inventoryBoxes.Add(maceaBox);
            inventoryBoxes.Add(bluePotionBox);
            inventoryBoxes.Add(redPotionBox);
        }
        //Makes Boxes transparent that are not equipped weapon
        public void MakeBoxesTransparent(string equippedBoxName)
        {
            foreach(PictureBox box in inventoryBoxes)
            {
                if(box.Name != equippedBoxName)
                {
                    box.BackColor = System.Drawing.Color.Transparent;
                }
            }
        }
    }
}
