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
using System.IO;

namespace ForeFather
{
    class Menu
    {
        private TextBox startNode;
        private TextBox currentNode;
        private bool display;
        public bool Display { get; set; }

        public Menu(MenuNode node)
        {
            currentNode = node;
            display = false;
            startNode = node;
        }

        public void Update(KeyboardState kb, KeyboardState oldKB)
        {

            if (currentNode is MenuNode)
            {
                MenuNode castNode = (MenuNode)currentNode;
                int index = castNode.CurOption;
                ((MenuNode)currentNode).Update(index);
                if (kb.IsKeyDown(Keys.Down) && !oldKB.IsKeyDown(Keys.Down))
                {
                    if (index == castNode.Options.Count - 1)
                    {
                        castNode.Update(0);
                    }
                    else
                    {
                        castNode.Update(index + 1);
                    }
                    currentNode = castNode;
                }
                if (kb.IsKeyDown(Keys.Up) && !oldKB.IsKeyDown(Keys.Up))
                {
                    if (index == 0)
                    {
                        castNode.Update(castNode.Options.Count - 1);
                    }
                    else
                    {
                        castNode.Update(index - 1);
                    }
                    currentNode = castNode;
                }
                if (kb.IsKeyDown(Keys.Enter) && !oldKB.IsKeyDown(Keys.Enter))
                {
                    if (castNode.Options != null || castNode.Options.Count != 0)
                    {
                        currentNode.exit();
                        currentNode = castNode.Options[index];
                        currentNode.Display();
                    }
                }
                if (kb.IsKeyDown(Keys.Back) && !oldKB.IsKeyDown(Keys.Back))
                {
                    if (castNode.Previous != null)
                    {
                        currentNode.exit();
                        currentNode = castNode.Previous;
                        currentNode.Display();
                    }
                    else
                    {
                        
                        Close();
                    }
                }
            }
            else
            {
                if (kb.IsKeyDown(Keys.Back) && !oldKB.IsKeyDown(Keys.Back) || kb.IsKeyDown(Keys.Enter) && !oldKB.IsKeyDown(Keys.Enter))
                {
                    Close();
                }
            }
        }

        public void Start()
        {
            currentNode.Display();
            display = true;
        }

        public void Close()
        {
            currentNode.exit();
            currentNode = startNode;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentNode.Draw(spritebatch);
        }
    }
}
