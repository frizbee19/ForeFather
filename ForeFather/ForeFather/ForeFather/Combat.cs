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
        private List<Character> allies;
        private List<Character> enemies;
        private Rectangle selection;
        private Texture2D selectionTex;
        private int choice;

        public Combat(ContentManager content)
        {
            selectionTex = content.Load<Texture2D>("blank");
            selection = new Rectangle(0, 0, 28, 28);
        }
        
        public void Draw(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, "1. Bash \n2. Abilities \n3. Goods \n4. Run", new Vector2(0, 0), Color.White);
            spriteBatch.Draw(selectionTex, selection, new Color(255,0,0,75));
            
            
        }

        public void DrawText()
        {
            
        }

        public void makeChoice()
        {

        }

        public void update(KeyboardState kb, KeyboardState oldkb)
        {
            kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Down) && !oldkb.IsKeyDown(Keys.Down))
            {
                
            }

            oldkb = kb;
        }
    }
}
