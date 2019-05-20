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
        //Bank is for gambling
        //Consume is for buying potions and food
        //Equip is buying weapons, armor, crystals
        //Hospital is healing for a fraction of your money, 10%
        //Inn is for restoring your mana for a fraction of your money, 20%
        public Rectangle Location
        {
            get { return location; }
            set { location = value; }
        }
        public void SetLocation(int x, int y)
        {
            location.X = x;
            location.Y = y;
        }
        private Texture2D texture;
        private Rectangle location;
        //the font needs to be monotype or whatever it is called so that it is easier to fit in the dialogue box
        private SpriteFont font;
        private ContentManager Content;
        private List<TextBox> dialogue;
        public TextBox Dialogue(int index)
        {
            return dialogue[index];
        }

        public String Name
        {
            get { return name; }
        }
        private string name;

        public NPC(int x, int y, string n, string )
        {
            location = new Rectangle(x, y, 34, 50);
            name = n;
            Content.RootDirectory = "Content";
            dialogue = new List<TextBox>();
            LoadContent();
        }

        public void LoadContent()
        {
            texture = Content.Load<Texture2D>("NPCtexture.png");

        }
        



        //public void ReadFile(string path, int maxLength)
        //{
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(path))
        //        {
        //            while (!reader.EndOfStream)
        //            {
        //                //implement something that will prevent the line from extending the length
        //                string line = reader.ReadLine();
        //                //to separate into smaller lines
        //                List<string> tempLines = new List<string>();
        //                string[] words = line.Split(' ');
        //                lines.Add("");
        //                for(int i = 0; i < words.Length; i++)
        //                {
        //                    if(tempLines[tempLines.Count - 1].Length + words[i].Length < maxLength)
        //                    {
        //                        tempLines[tempLines.Count - 1] += " " + words[i];
        //                    }
        //                    else
        //                    {
        //                        tempLines.Add(words[i]);
        //                    }
        //                }
                        
        //                for(int i = 0; i < tempLines.Count; i++)
        //                {
        //                    lines.Add(tempLines[0]);
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine("lmao an error, you suck: " + e.Message);
        //    }
        //}

        


    }
}
