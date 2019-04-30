using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ForeFather
{
    class Combat
    {
        TextBox comText;
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Rectangle selectRect;
        Texture2D selectTex;

        private int choice = 0;
        private List<Ally> allies;
        private List<Enemy> enemies;
        private bool turn;
        int currentMember;
        private bool isPrinting;
        
        Random rand = new Random();
        string text;

        public Combat(ContentManager content, List<Ally> allies, List<Enemy> enemies)
        {
            this.allies = allies;
            this.enemies = enemies;
            this.content = content;

            //if (rand.Next(1) == 0) //coinflip for first turn
            //    turn = false;
            //else
                turn = true;

            initialize();
        }

        public void initialize()
        {
            text = "Bash \nAbilities \nGoods \nRun";
            comText = new TextBox(new Rectangle(10,10, 780, 250), 100,text, false, content);
            selectRect = new Rectangle(0, 70, 25, 25);
            currentMember = 0;
            isPrinting = false;
        }

        public void loadContent(ContentManager content, SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            selectTex = content.Load<Texture2D>("arrow");
        }

        public void update(KeyboardState kb, KeyboardState oldkb)
        {
            
            if (turn == true)
            {
                if (isPrinting == false)
                {

                    switch (select(4, kb, oldkb))
                    {

                        case 0:
                            
                            currentMember++;
                            break;
                        case 1:
                            
                            currentMember++;
                            break;
                        case 2:
                            currentMember++;
                            break;
                        case 3:
                            currentMember++;
                            break;
                        default:
                            break;


                    }

                    if (currentMember >= allies.Count)
                    {
                        currentMember = 0;
                        turn = false;
                        selectRect = new Rectangle(0, 70, 25, 25);
                    }
                }
            }
            else if (turn == false)
            {
                for (int i = 0; i < enemies.Count; i++) //loops through each enemy
                {
                    comText = new TextBox(new Rectangle(10, 10, 780, 250), 100, "Enemy Turn", false, content);
                }
            }
        }

        public void draw()
        {

            comText.Draw(spriteBatch);
            if (turn == true)
                spriteBatch.Draw(selectTex, selectRect, Color.White);
            
        }

        private int select(int numChoices, KeyboardState kb, KeyboardState oldkb)
        {
                if (kb.IsKeyDown(Keys.Down) && !oldkb.IsKeyDown(Keys.Down))
                {

                    selectRect.Y += 30;
                    choice++;


                }
                if (kb.IsKeyDown(Keys.Up) && !oldkb.IsKeyDown(Keys.Up))
                {
                    selectRect.Y -= 30;
                    choice--;
                }
                if (choice >= numChoices || choice < 0)
                {
                    choice = 0;
                    selectRect.Y = 70;
                }

            if (kb.IsKeyDown(Keys.Enter) && !oldkb.IsKeyDown(Keys.Enter))
            {
                return choice;
            }
            else
                return numChoices + 5;
        }

        private void printInfo()
        {
            isPrinting = true;



        }

        //TODO: makechoice function
    }
}
