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
        private List<Ally> allies;
        private List<Enemy> enemies;
        private Rectangle selection;
        private Texture2D selectionTex;
        private int choice;
        string combatText = "";

        public Combat(ContentManager content, List<Ally> allies, List<Enemy> enemies)
        {
            selectionTex = content.Load<Texture2D>("blank");
            selection = new Rectangle(0, 0, 28, 28);
            allies[0].getTurn = true;
            //enemies[0].getTurn = false;
            this.allies = allies;
            this.enemies = enemies;
        }
        
        public void Draw(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            if (allies[0].getTurn == true)
            {
                spriteBatch.DrawString(spriteFont, "1. Bash \n2. Abilities \n3. Goods \n4. Run", new Vector2(0, 0), Color.White);
                spriteBatch.Draw(selectionTex, selection, new Color(255, 0, 0, 75));
                
            }

            DrawText(combatText, spriteFont, spriteBatch);
        }

        public void DrawText(string text, SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, text, new Vector2(100, 200), Color.White);
        }

        public void makeChoice()
        {

        }

        public void update(KeyboardState kb, KeyboardState oldkb)
        {
            if (allies[0].getTurn == true)
            {
                if (kb.IsKeyDown(Keys.Down) && !oldkb.IsKeyDown(Keys.Down))
                {
                    selection.Y += 26;
                }
                if (kb.IsKeyDown(Keys.Up) && !oldkb.IsKeyDown(Keys.Up))
                {
                    selection.Y -= 26;
                }
                if (kb.IsKeyDown(Keys.Enter) && !oldkb.IsKeyDown(Keys.Enter))
                {
                    if (selection.Y == 0)
                    {
                        allies[0].attack(enemies[0]);
                        enemies[0].getTurn = true;
                        combatText = "attack did " + 10 + " damage to enemy";
                    }
                }
            }
            if (enemies[0].getTurn == true)
            {
                enemies[0].getTurn = false;
                allies[0].getTurn = true;
            }


        }
      }
    }

