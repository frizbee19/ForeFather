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
    class NPC
    {
        public Rectangle Location
        {
            get { return location; }
            set { location = value; }
        }
        public void set(int x, int y)
        {
            location.X = x;
            location.Y = y;
        }
        private Texture2D texture;
        private Rectangle location;
        private List<string> lines;
        //the font needs to be monotype or whatever it is called so that it is easier to fit in the dialogue box
        private SpriteFont font;
        private ContentManager Content;
        private int lineLength;

        public NPC(int x, int y)
        {
            location = new Rectangle(x, y, 34, 50);
            lines = new List<string>();
            //placeholder length
            lineLength = 30;
            Content.RootDirectory = "Content";
            LoadContent();
        }

        public void LoadContent()
        {
            texture = Content.Load<Texture2D>("NPCtexture.png");

        }

        public void ReadFile(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        //implement something that will prevent the line from extending the length
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                }
            }
            catch()
        }

        


    }
}
