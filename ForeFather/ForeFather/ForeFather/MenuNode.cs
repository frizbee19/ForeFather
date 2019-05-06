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
    //this is gonna be for the menu class, which will be a tree. menu will be used in the main game class and will keep track of the current node.
    class MenuNode : TextBox
    {
        //private List<Ally> allies;
        //private int curOption;
        private List<TextBox> options;
        private MenuNode previous;
        public MenuNode Previous { get; set; }
        private int curOption;

        public MenuNode(string p, ContentManager content, string name) : base(new Rectangle(30, 30, 400, 400), p, false, content, name)
        {
            //allies = new List<Ally>();
            options = new List<TextBox>();
            curOption = 0;
            previous = null;
            //curOption = 0;
        }

        public MenuNode(MenuNode prev, string p, ContentManager content, string name) : base(new Rectangle(30, 30, 400, 400), p, false, content, name)
        {
            //allies = new List<Ally>();
            options = new List<TextBox>();
            curOption = 0;
            previous = prev;
            //curOption = 0;
        }

        public void AddNode(MenuNode node)
        {
            options.Add(node);
        }


        public void Update(int currentInd)
        {
            if (currentInd != curOption)
            {
                curOption = currentInd;
                lines.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == curOption)
                    {
                        lines.Add(">" + options[i].Title);
                    }
                    else
                    {
                        lines.Add(options[i].Title);
                    }
                }
            }
        }
        ////controls
        //public void Update(KeyboardState kb, KeyboardState oldKB)
        //{
        //    if(kb.IsKeyDown(Keys.Down) && !oldKB.IsKeyDown(Keys.Down))
        //    {
        //        if(curOption == options.Count - 1)
        //        {
        //            curOption = 0;
        //        }
        //        else
        //        {
        //            curOption++;
        //        }
        //    }
        //    if (kb.IsKeyDown(Keys.Up) && !oldKB.IsKeyDown(Keys.Up))
        //    {
        //        if (curOption == 0)
        //        {
        //            curOption = options.Count - 1;
        //        }
        //        else
        //        {
        //            curOption--;
        //        }
        //    }
        //    //if(kb.IsKeyDown(Keys.Enter))
        //}

        public new void Draw(SpriteBatch spritebatch)
        {
            if(isDisplaying())
            {
                spritebatch.Draw(Content.Load<Texture2D>("black or something"), Box, Color.White);
                spritebatch.DrawString(NameFont, Title, new Vector2(Box.X + 5, Box.Y + 5), Color.White);
                for(int i = 0; i < lines.Count; i++)
                {
                    spritebatch.DrawString(Font, lines[i], new Vector2(Box.X + 15, Box.Y + 35 + (i * 35)), Color.White);
                }

            }
        }

    }
}
