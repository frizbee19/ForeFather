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

        TextBox tempText;

        ContentManager content;

        SpriteBatch spriteBatch;

        SpriteFont spriteFont;

        TextBox ally1;

        TextBox ally2;

        TextBox ally3;

        TextBox ally4;

        Rectangle selectRect;

        Texture2D selectTex;

        private int choice = 0;

        int stopwatch = 0;

        private List<Ally> allies;

        private List<Enemy> enemies;

        private bool turn;

        int currentMember;

        private bool isPrinting;

        string ally1Text;

        string ally2Text;

        string ally3Text;

        string ally4Text;
        
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
            comText = new TextBox(new Rectangle(10,10, 780, 250),text, false, content);
            ally1Text = "HP: " + allies[0].getCurHp + "\nMP: " + allies[0].getMana;
            ally2Text = "";
            ally3Text = "";
            ally4Text = "";
            ally1 = new TextBox(new Rectangle(10, 600, 175, 250), ally1Text, false, content, "Arlo");
            ally2 = new TextBox(new Rectangle(210, 600, 175, 250), ally2Text, false, content, "Hunter");
            ally3 = new TextBox(new Rectangle(415, 600, 175, 250), ally3Text, false, content, "Jac-E");
            ally4 = new TextBox(new Rectangle(615, 600, 175, 250), ally4Text, false, content, "Noire");
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
            //turns and selection
            if (isPrinting == false)
            {
                if (turn == true) //ALLY TURN
                {
                    ally1Text = "HP: " + allies[0].getCurHp + "\nMP: " + allies[0].getMana;

                    ally1 = new TextBox(new Rectangle(10, 600, 175, 250), ally1Text, false, content, "Arlo");

                    ally2 = new TextBox(new Rectangle(210, 600, 175, 250), ally2Text, false, content, "Hunter");

                    ally3 = new TextBox(new Rectangle(415, 600, 175, 250), ally3Text, false, content, "Jac-E");

                    ally4 = new TextBox(new Rectangle(615, 600, 175, 250), ally4Text, false, content, "Noire");


                    if (currentMember >= allies.Count) //hand turn back to enemy 
                    {
                        currentMember = 0;
                        turn = false;
                        selectRect = new Rectangle(0, 70, 25, 25);
                    }

                    switch (select(4, kb, oldkb))
                    {

                        case 0:

                            currentMember++; // increments to next members turn
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



                }
                else if (turn == false) //ENEMY TURN
                {
                    


                    
                    if (!isPrinting && currentMember < enemies.Count) //enemy turn
                    {
                        //if ()
                        //{
                            enemies[currentMember].attack(allies[0]);
                            comText = new TextBox(new Rectangle(10, 10, 780, 250), 100, enemies[currentMember].getName + " bashed " + allies[0].getName + " for "
                                                                + 5 * (1 + ((enemies[currentMember].getOffense / 100) - (allies[0].getDefense / 100))), false, content);

                        //}
                        isPrinting = true;
                        currentMember++;
                    }

                       
                    

                    if (currentMember >= enemies.Count && !isPrinting) //hand turn back to ally
                    {
                        currentMember = 0;
                        turn = true;
                        comText = new TextBox(new Rectangle(10, 10, 780, 250), 100, text, false, content);
                    }


                }
            }

            if (isPrinting == true)
            {
                stopwatch++;
                if (stopwatch % 180 == 0)
                {
                    isPrinting = false;
                    stopwatch = 0;
                }
                
            }

            //DISPLAY CHARACTERS


                
            
            
        }

        public void draw()
        {

            comText.Draw(spriteBatch);
            ally1.Draw(spriteBatch);
            ally2.Draw(spriteBatch);
            ally3.Draw(spriteBatch);
            ally4.Draw(spriteBatch);

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

        //TODO: makechoice function
    }
}
