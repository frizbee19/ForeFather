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
    public class Combat
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

        Game1 game;

        int currentMember;

        private bool isPrinting;

        string ally1Text;

        string ally2Text;

        string ally3Text;

        string ally4Text;

        string currentTurn = "";
        
        Random rand = new Random();

        string text;

        //true is ally
        //false is enemy
        public bool getTurnStatus()
        {
            return turn;
        }

        public Combat(ContentManager content, List<Ally> allies, List<Enemy> enemies, Game1 game)
        {
            this.allies = allies;
            this.enemies = enemies;
            this.content = content;
            this.game = game;

            //if (rand.Next(1) == 0) //coinflip for first turn
            //    turn = false;
            //else
                turn = true;

            initialize();
        }

        public void initialize()
        {
            text = "Bash \nAbilities \nGoods \nRun";
            comText = new TextBox(new Rectangle(10,10, 780, 250),text, false, content, currentTurn);
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

                        //Text display gibberish

                        if (currentMember == 0)
                            currentTurn = "Arlo";
                        if (currentMember == 1)
                            currentTurn = "Hunter";
                        if (currentMember == 2)
                            currentTurn = "Jac-E";
                        if (currentMember == 3)
                            currentTurn = "Noire";

                        text = "Bash \nAbilities \nGoods \nRun";

                        ally1Text = "HP: " + allies[0].getCurHp + "\nMP: " + allies[0].getMana;
                        if (allies.Count >= 2)
                            ally2Text = "HP: " + allies[1].getCurHp + "\nMP: " + allies[1].getMana;
                        if (allies.Count >= 3)
                            ally3Text = "HP: " + allies[2].getCurHp + "\nMP: " + allies[2].getMana;
                        if (allies.Count >= 4)
                            ally4Text = "HP: " + allies[3].getCurHp + "\nMP: " + allies[3].getMana;


                        ally1 = new TextBox(new Rectangle(10, 600, 175, 250), ally1Text, false, content, "Arlo");

                        ally2 = new TextBox(new Rectangle(210, 600, 175, 250), ally2Text, false, content, "Hunter");

                        ally3 = new TextBox(new Rectangle(415, 600, 175, 250), ally3Text, false, content, "Jac-E");

                        ally4 = new TextBox(new Rectangle(615, 600, 175, 250), ally4Text, false, content, "Noire");



                        //hand turn back to enemy 
                        if (currentMember >= allies.Count)
                        {
                            currentMember = 0;
                            turn = false;
                            selectRect = new Rectangle(0, 70, 25, 25);
                        }

                        switch (select(4, kb, oldkb))
                        {

                            case 0:

                                allies[currentMember].attack(enemies[0]);
                                text = allies[currentMember].getName + " bashed " + enemies[0].getName + " for " + 5 * (1 + ((allies[currentMember].getOffense / 100) - (enemies[0].getDefense / 100)));
                                isPrinting = true;
                                currentMember++; // increments to next members turn
                                break;
                            case 1:
                                Ability test = allies[currentMember].getAbility;
                                test.applyDoT(3, 1, enemies[0], this);
                                text = enemies[0].getName + " took some damage!";
                                isPrinting = true;
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

                        currentTurn = "Enemy";


                        if (!isPrinting && currentMember < enemies.Count) //enemy turn
                        {
                            enemies[currentMember].attack(allies[0]);
                            text = enemies[currentMember].getName + " bashed " + allies[0].getName + " for " + 5 * (1 + ((enemies[currentMember].getOffense / 100) - (allies[0].getDefense / 100)));
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

                if (enemies[0].getCurHp <= 0)
                {
                    Game1.currentMap = map.Town;
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



            comText = new TextBox(new Rectangle(10, 10, 780, 250), text, false, content, currentTurn);
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
