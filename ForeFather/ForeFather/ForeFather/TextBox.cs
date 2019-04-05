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
    class TextBox
    {
        private Rectangle box;
        //for the texture, just put like a black box or something. its for the background of the textbox
        private Texture2D texture;
        private const int DEFAULT_X = 25;
        private const int DEFAULT_Y = 500;
        private const int DEFAULT_WIDTH = 750;
        private const int DEFAULT_HEIGHT = 250;
        private List<string> lines;
        private const int DEFAULT_LINELENGTH = 40;
        private int lineLength;
        private SpriteFont font;
        private string path;
        private int currentInd;
        private ContentManager Content;
        public int currentIndex
        {
            get { return currentInd; }
        }

        public TextBox(Texture2D t, Rectangle rect, int length, string p, bool fromAFile, ContentManager Content)
        {
            texture = t;
            box = rect;
            lineLength = length;
            path = p;
            lines = new List<string>();
            currentInd = 0;
            font = Content.Load<SpriteFont>("dialFont");
            if (fromAFile)
            {
                ReadFile(@path);
            }
            else
            {
                ReadString(path);
            }
        }

        public TextBox(Texture2D t, int length, string p, bool fromAFile, ContentManager Content) : this(t, new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), length, p, fromAFile, Content)
        {

        }

        public TextBox(Texture2D t, Rectangle rect, string p, bool fromAFile, ContentManager Content) : this(t, rect, DEFAULT_LINELENGTH, p, fromAFile, Content)
        {

        }

        public TextBox(Texture2D t, string p, bool fromAFile, ContentManager Content) : this(t, new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), DEFAULT_LINELENGTH, p, fromAFile, Content)
        {

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
                        //to separate into smaller lines
                        List<string> tempLines = new List<string>();
                        string[] words = line.Split(' ');
                        lines.Add("");
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (tempLines[tempLines.Count - 1].Length + words[i].Length < lineLength)
                            {
                                tempLines[tempLines.Count - 1] += " " + words[i];
                            }
                            else
                            {
                                tempLines.Add(words[i]);
                            }
                        }

                        for (int i = 0; i < tempLines.Count; i++)
                        {
                            lines.Add(tempLines[i]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("lmao an error, you suck: " + e.Message);
            }
        }

        //USE THIS IF USING A STRING INSTEAD OF A FILE
        public void ReadString(string path)
        {
            List<string> tempLines = new List<string>();
            string[] words = path.Split(' ');
            tempLines.Add("");
            for (int i = 0; i < words.Length; i++)
            {
                if (tempLines[tempLines.Count - 1].Length + words[i].Length < lineLength)
                {
                    tempLines[tempLines.Count - 1] += words[i] + " ";
                }
                else
                {
                    tempLines.Add(words[i] + " ");
                }
            }

            for (int i = 0; i < tempLines.Count; i++)
            {
                lines.Add(tempLines[i]);
            }
            //for(int i = 0; i < lines.Count; i++)
            //{
            //    Console.WriteLine(lines[i]);
            //}
        }

        public void scroll()
        {
            if (currentInd < lines.Count - 1)
            {
                currentInd++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, box, Color.White);
            spriteBatch.DrawString(font, lines[currentInd], new Vector2(box.X + 20, box.Y + 30), Color.White);
            if (lines.Count > 1)
            {
                spriteBatch.DrawString(font, lines[currentInd + 1], new Vector2(box.X + 20, box.Y + 90), Color.White);
            }
        }

    }
}
