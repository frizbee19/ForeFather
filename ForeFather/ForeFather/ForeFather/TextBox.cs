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
        private SpriteFont nameFont;
        private string path;
        private int currentInd;
        bool displayBox;
        private ContentManager Content;
        private string title;
        private bool displayBox;
        public int currentIndex
        {
            get { return currentInd; }
        }

        public TextBox(Rectangle rect, int length, string p, bool fromAFile, ContentManager Content, string name)
        {
            title = name;
            box = rect;
            lineLength = length;
            path = p;
            lines = new List<string>();
            currentInd = 0;
            font = Content.Load<SpriteFont>("dialFont");
            nameFont = Content.Load<SpriteFont>("nameFont");
            texture = Content.Load<Texture2D>("black or something");
            if (fromAFile)
            {
                ReadFile(@path);
            }
            else
            {
                ReadString(path);
            }
        }

        public TextBox(Rectangle rect, int length, string p, bool fromAFile, ContentManager Content) : this(rect, length, p, fromAFile, Content, "")
        {

        }

        public TextBox(int length, string p, bool fromAFile, ContentManager Content) : this(new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), length, p, fromAFile, Content)
        {

        }

        public TextBox(Rectangle rect, string p, bool fromAFile, ContentManager Content) : this(rect, DEFAULT_LINELENGTH, p, fromAFile, Content)
        {

        }

        public TextBox(string p, bool fromAFile, ContentManager Content) : this(new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), DEFAULT_LINELENGTH, p, fromAFile, Content) //basic text box, use this.
        {

        }

        public TextBox(int length, string p, bool fromAFile, ContentManager Content, string name) : this(new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), length, p, fromAFile, Content, name)
        {

        }

        public TextBox(Rectangle rect, string p, bool fromAFile, ContentManager Content, string name) : this(rect, DEFAULT_LINELENGTH, p, fromAFile, Content, name)
        {

        }

        public TextBox(string p, bool fromAFile, ContentManager Content, string name) : this(new Rectangle(DEFAULT_X, DEFAULT_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT), DEFAULT_LINELENGTH, p, fromAFile, Content, name)
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
                        tempLines.Add("");
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (tempLines[tempLines.Count - 1].Length + words[i].Length < lineLength)
                            {
                                tempLines[tempLines.Count - 1] +=  words[i] + " ";
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
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("lmao an error, you suck: " + e.Message);
            }
        }
        //use this to display the textbox
        public void Display()
        {
            displayBox = true;
        }
        public bool isDisplaying()
        {
            return displayBox;
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

        public void Display()
        {
            displayBox = true;
        }

        public void scroll()
        {
            if (currentInd < lines.Count - 2)
            {
                currentInd++;
            }
            else if(currentInd == lines.Count - 2)
            {
                displayBox = false;
                currentInd = 0;
            }
        }

        public void exit()
        {
            displayBox = false;
            currentInd = 0;
        }

        public void Display()
        {
            displayBox = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(texture, box, Color.White);
                spriteBatch.DrawString(nameFont, title, new Vector2(box.X + 5, box.Y + 5), Color.White);
                spriteBatch.DrawString(font, lines[currentInd], new Vector2(box.X + 20, box.Y + 50), Color.White);
                if (lines.Count > 1)
                {
                    spriteBatch.DrawString(font, lines[currentInd + 1], new Vector2(box.X + 20, box.Y + 130), Color.White);
                }
            
        }

    }
}
