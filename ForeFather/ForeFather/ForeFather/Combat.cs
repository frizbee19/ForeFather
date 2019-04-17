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

        private List<Ally> allies;
        private List<Enemy> enemies;
        private bool turn;
        Random rand = new Random();
        string text;

        public Combat(ContentManager content, List<Ally> allies, List<Enemy> enemies)
        {
            this.allies = allies;
            this.enemies = enemies;
            this.content = content;

            if (rand.Next(1) == 0) //coinflip for first turn
                turn = false;
            else
                turn = true;

            initialize();
        }

        public void initialize()
        {
            text = "Bash \nAbilities \nGoods \nRun";
            comText = new TextBox(new Rectangle(10,10, 780, 250), 100,text, false, content);
            
        }

        public void loadContent(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
        }

        public void update(KeyboardState kb, KeyboardState oldkb)
        {
            if (turn == true)
            {
                for (int i = 0; i < allies.Count; i++) //loops through each ally
                {
                    //makechoice
                }
            }
            else if (turn == false)
            {
                for (int i = 0; i < enemies.Count; i++) //loops through each enemy
                {
                    //AI
                }
            }
        }

        public void draw()
        {
            
            comText.Draw(spriteBatch);
            
        }

        private int select(int numChoices, KeyboardState kb, KeyboardState oldkb)
        {
            
        }

        //TODO: makechoice function
    }
}
