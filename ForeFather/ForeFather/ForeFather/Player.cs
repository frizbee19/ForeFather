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
    class Player
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Rectangle sourceRectangle;
        private int trail;
        private const int MS = 3;
        private const int WIDTH = 34;
        private const int HEIGTH = 50;
        Keys lastKey;
        string character;

        public Player(ContentManager content, Rectangle rect, int t, int i)
        {
            texture = content.Load<Texture2D>("spriteChar");
            rectangle = new Rectangle(rect.X, rect.Y, WIDTH, HEIGTH);
            trail = t;
            
            switch (i)
            {
                case 0:
                    sourceRectangle = new Rectangle(0, 0, 106, 193);
                    character = "mage";
                    break;
                case 1:
                    sourceRectangle = new Rectangle(0, 193, 101, 181);
                    character = "knight";
                    break;
                case 2:
                    sourceRectangle = new Rectangle(0, 374, 101, 185);
                    character = "rouge";
                    break;
                case 3:
                    sourceRectangle = new Rectangle(0, 559, 110, 183);
                    character = "princess?";
                    break;
                default:
                    throw new Exception("The value provided for identifier (i) is invalid. 0 <= i <= 3");
            }
        }

        public void update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                rectangle.Y -= MS;
                lastKey = Keys.Up;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                rectangle.Y += MS;
                lastKey = Keys.Down;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rectangle.X -= MS;
                lastKey = Keys.Left;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rectangle.X += MS;
                lastKey = Keys.Right;
            }

            switch (character)
            {
                case "mage":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(193, 0, 106, 193);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 0, 106, 193);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(299, 0, 87, 193);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(106, 0, 87, 193);
                            break;
                    }
                    break;
                case "knight":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(181, 193, 101, 181);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 193, 101, 181);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(282, 193, 80, 181);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(101, 193, 80, 181);
                            break;
                    }
                    break;
                case "rouge":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(184, 374, 101, 185);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 374, 101, 185);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(285, 374, 83, 185);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(101, 374, 83, 185);
                            break;
                    }
                    break;
                case "princess?":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(188, 559, 110, 183);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 559, 110, 183);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(298, 559, 78, 183);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(110, 559, 78, 183);
                            break;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }
    }
}
