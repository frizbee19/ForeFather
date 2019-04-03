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
        private const int DEFAULT_X = 50;
        private const int DEFAULT_Y = 500;
        private const int DEFAULT_WIDTH = 700;
        private const int DEFAULT_HEIGHT = 200;
        private List<string> lines;
        private const int DEFAULT_LINELENGTH = 30;
        private int lineLength;
        private SpriteFont font;
        private string path;
        private int currentInd;
        public int currentIndex
        {
            get { return currentInd; }
        }

        public TextBox(Texture2D t, Rectangle rect, int length, string p)
        {
            texture = t;
            box = rect;
            lineLength = length;
            path = p;
            ReadFile(@path);
            lines = new List<string>();
            currentInd = 1;
        }

        public TextBox(Texture2D t, int x, int y, int width, int height, int length, string p) : this(t, new Rectangle(x, y, width, height), length, p)
        {

        }

        public TextBox(Texture2D t, int length, string p) : this(t, new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), length, p)
        {

        }

        public TextBox(Texture2D t, Rectangle rect, string p) : this(t, rect, DEFAULT_LINELENGTH, p)
        {

        }

        public TextBox(Texture2D t, int x, int y, int width, int height, string p) : this(t, new Rectangle(x, y, width, height), DEFAULT_LINELENGTH, p)
        {

        }

        public TextBox(Texture2D t, string p) : this(t, new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), DEFAULT_LINELENGTH, p)
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
                            lines.Add(tempLines[0]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("lmao an error, you suck: " + e.Message);
            }
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
            spriteBatch.DrawString(font, lines[currentInd - 1], new Vector2(box.X + 30, box.Y + 30), Color.White);
            spriteBatch.DrawString(font, lines[currentInd], new Vector2(box.X + 80, box.Y + 80), Color.White);
        }

    }
}
