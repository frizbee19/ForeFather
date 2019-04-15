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

        private List<Ally> allies;
        private List<Enemy> enemies;
        private bool turn;
        Random rand = new Random();

        public Combat(ContentManager content, SpriteFont spriteFont, SpriteBatch spriteBatch, List<Ally> allies, List<Enemy> enemies)
        {
            this.allies = allies;
            this.enemies = enemies;
            this.content = content;
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;

            if (rand.Next(1) == 0)
                turn = false;
            else
                turn = true;
        }

        public void initialize()
        {
            comText = new TextBox("haha", false, content);
        }

        public void update()
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
            comText.Draw();
        }

        //TODO: makechoice function
    }
}
