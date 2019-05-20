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
        private Rectangle[] rectangles;
        private Rectangle[] sourceRectangles;
        private int trail;
        private const int MS = 5;
        private const int WIDTH = 34;
        private const int HEIGTH = 50;
        Keys lastKey;
        string character;

        public Player(ContentManager content, Rectangle rect, int t)
        {
            rectangles = new Rectangle[4];
            sourceRectangles = new Rectangle[4];
            texture = content.Load<Texture2D>("Assets\\spriteChar");
            rectangles[0] = new Rectangle(rect.X, rect.Y, WIDTH, HEIGTH);
            rectangles[1] = new Rectangle(rectangles[0].Width + WIDTH + MS, rect.Y, WIDTH, HEIGTH);
            rectangles[2] = new Rectangle(rectangles[1].Width + WIDTH + MS, rect.Y, WIDTH, HEIGTH);
            rectangles[3] = new Rectangle(rectangles[2].Width + WIDTH + MS, rect.Y, WIDTH, HEIGTH);
            trail = t;           
                    sourceRectangles[2] = new Rectangle(0, 0, 106, 193);
                    sourceRectangles[0] = new Rectangle(0, 193, 101, 181);
                    sourceRectangles[1] = new Rectangle(0, 374, 101, 185);
                    sourceRectangles[3] = new Rectangle(0, 559, 110, 183);
            
        }

        public void setCoords(int newX, int newY)
        {
            rectangles[0].X = newX;
            rectangles[0].Y = newY;
            rectangles[1].X = newX;
            rectangles[1].Y = newY;
            rectangles[2].X = newX;
            rectangles[2].Y = newY;
            rectangles[3].X = newX;
            rectangles[3].Y = newY;
        }

        public map update(Dictionary<string, Building> buildings, map current, Tile[,] tiles)
        {
            int currentGridY = rectangles[0].X / 50;
            if (rectangles[0].X >= 800)
                currentGridY = 0;
            int currentGridX = rectangles[0].Y / 50;
            if (rectangles[0].Y >= 800)
                currentGridX = 0;


            if (Keyboard.GetState().IsKeyDown(Keys.Up) && rectangles[0].Y > 0)
            {
                rectangles[0].Y -= MS;
                if (tiles[currentGridX, currentGridY].Intersects(this) || (currentGridX < 15 && tiles[currentGridX+1, currentGridY].Intersects(this)) || (currentGridY < 15 && tiles[currentGridX, currentGridY+1].Intersects(this)) || (currentGridX < 15 &&  currentGridY<15 && tiles[currentGridX + 1, currentGridY+1].Intersects(this)))
                {
                    rectangles[0].Y += MS;
                }
                else if (Intersects(buildings, current).Equals("0") && current != map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangles[0].Y += MS;

                lastKey = Keys.Up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && rectangles[0].Y <= 0)
            {
                rectangles[0].Y -= MS;
                if (current == map.Town)
                {
                    rectangles[0].Y = 800;
                    rectangles[1].Y = 800;
                    rectangles[2].Y = 800;
                    rectangles[3].Y = 800;
                    current = map.Wild2;
                }
                else
                    rectangles[0].Y += MS;

                lastKey = Keys.Up;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && rectangles[0].Y+ rectangles[0].Height<800)
            {
                rectangles[0].Y += MS;
                if (tiles[currentGridX, currentGridY].Intersects(this) || (currentGridX < 15 && tiles[currentGridX + 1, currentGridY].Intersects(this)) || (currentGridY < 15 && tiles[currentGridX, currentGridY + 1].Intersects(this)) || (currentGridX < 15 && currentGridY < 15 && tiles[currentGridX + 1, currentGridY + 1].Intersects(this)))
                {
                    rectangles[0].Y -= MS;
                }
                else if (Intersects(buildings, current).Equals("0") && current != map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangles[0].Y -= MS;

                lastKey = Keys.Down;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && rectangles[0].Y + rectangles[0].Height >= 800)
            {
                rectangles[0].Y += MS;
                
                if (current == map.Wild2)
                {
                    rectangles[0].Y = 0;
                    rectangles[1].Y = 0;
                    rectangles[2].Y = 0;
                    rectangles[3].Y = 0;
                    current = map.Town;
                    if (Intersects(buildings, current).Equals("0"))
                    {
                        rectangles[0].Y = 800 - HEIGTH;
                        rectangles[1].Y = 800 - HEIGTH;
                        rectangles[2].Y = 800 - HEIGTH;
                        rectangles[3].Y = 800 - HEIGTH;
                        current = map.Wild2;
                    }
                }
                else
                    rectangles[0].Y -= MS;

                lastKey = Keys.Down;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && rectangles[0].X>0)
            {
                rectangles[0].X -= MS;
                if (tiles[currentGridX, currentGridY].Intersects(this) || (currentGridX < 15 && tiles[currentGridX + 1, currentGridY].Intersects(this)) || (currentGridY < 15 && tiles[currentGridX, currentGridY + 1].Intersects(this)) || (currentGridX < 15 && currentGridY < 15 && tiles[currentGridX + 1, currentGridY + 1].Intersects(this)))
                {
                    rectangles[0].X += MS;
                }
                else if (Intersects(buildings, current).Equals("0") && current != map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangles[0].X += MS;

                lastKey = Keys.Left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && rectangles[0].X <= 0)
            {
                rectangles[0].X -= MS;
                if (current == map.Wild2)
                {
                    rectangles[0].X = 800 - WIDTH;
                    rectangles[1].X = 800 - WIDTH;
                    rectangles[2].X = 800 - WIDTH;
                    rectangles[3].X = 800 - WIDTH;
                    current = map.Wild1;
                }
                else if (current == map.Wild3)
                {
                    rectangles[0].X = 800 - WIDTH;
                    rectangles[1].X = 800 - WIDTH;
                    rectangles[2].X = 800 - WIDTH;
                    rectangles[3].X = 800 - WIDTH;
                    current = map.Wild2;
                }
                else
                    rectangles[0].X += MS;

                lastKey = Keys.Left;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && rectangles[0].X + rectangles[0].Width < 800)
            {
                rectangles[0].X += MS;
                if (tiles[currentGridX, currentGridY].Intersects(this) || (currentGridX < 15 && tiles[currentGridX + 1, currentGridY].Intersects(this)) || (currentGridY < 15 && tiles[currentGridX, currentGridY + 1].Intersects(this)) || (currentGridX < 15 && currentGridY < 15 && tiles[currentGridX + 1, currentGridY + 1].Intersects(this)))
                {
                    rectangles[0].X -= MS;
                }
                else if (Intersects(buildings, current).Equals("0") && current!=map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangles[0].X -= MS;
                lastKey = Keys.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && rectangles[0].X + rectangles[0].Width >= 800)
            {
                rectangles[0].X += MS;
                if (current == map.Wild1)
                {
                    rectangles[0].X = 0;
                    rectangles[1].X = 0;
                    rectangles[2].X = 0;
                    rectangles[3].X = 0;
                    current = map.Wild2;
                }
                else if (current == map.Wild2)
                {
                    rectangles[0].X = 0;
                    rectangles[1].X = 0;
                    rectangles[2].X = 0;
                    rectangles[3].X = 0;
                    current = map.Wild3;
                }
                else
                    rectangles[0].X -= MS;

                lastKey = Keys.Left;
            }


            
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangles[2] = new Rectangle(193, 0, 106, 193);
                            sourceRectangles[0] = new Rectangle(181, 193, 101, 181);
                            sourceRectangles[1] = new Rectangle(184, 374, 101, 185);
                            sourceRectangles[3] = new Rectangle(188, 559, 110, 183);
                            break;
                        case Keys.Down:
                            sourceRectangles[2] = new Rectangle(0, 0, 106, 193);
                            sourceRectangles[0] = new Rectangle(0, 193, 101, 181);
                            sourceRectangles[1] = new Rectangle(0, 374, 101, 185);
                            sourceRectangles[3] = new Rectangle(0, 559, 110, 183);
                            break;
                        case Keys.Left:
                            sourceRectangles[2] = new Rectangle(299, 0, 87, 193);
                            sourceRectangles[0] = new Rectangle(282, 193, 80, 181);
                            sourceRectangles[1] = new Rectangle(285, 374, 83, 185);
                            sourceRectangles[3] = new Rectangle(298, 559, 78, 183);
                            break;
                        case Keys.Right:
                            sourceRectangles[2] = new Rectangle(106, 0, 87, 193);
                            sourceRectangles[0] = new Rectangle(101, 193, 80, 181);
                            sourceRectangles[1] = new Rectangle(101, 374, 83, 185);
                            sourceRectangles[3] = new Rectangle(110, 559, 78, 183);
                            break;
                    }
            updateAllies(lastKey);
            return current;
                  
            }
            
        private void updateAllies(Keys key)
        {
            int howFast = 10;
            for (int i = 3; i > 0; i--)
            {
                if (rectangles[i].X > rectangles[i-1].X + howFast/2)
                    rectangles[i].X -= (rectangles[i].X - (rectangles[i-1].X + howFast/2)) / howFast;
                else if (rectangles[i].X + howFast < rectangles[i-1].X)
                    rectangles[i].X += ((rectangles[i-1].X - howFast/2) - rectangles[i].X) / howFast;

                if (rectangles[i].Y > rectangles[i-1].Y + howFast/2)
                    rectangles[i].Y -= (rectangles[i].Y - (rectangles[i-1].Y + howFast/2)) / howFast;
                else if (rectangles[i].Y + howFast < rectangles[i-1].Y)
                    rectangles[i].Y += ((rectangles[i-1].Y - howFast/2) - rectangles[i].Y) / howFast;
            }
            //if (rectangles[2].X > rectangles[1].X + howFast)
            //    rectangles[2].X -= (rectangles[2].X - (rectangles[1].X + howFast)) / howFast;
            //else if (rectangles[2].X + howFast < rectangles[1].X)
            //    rectangles[2].X += ((rectangles[1].X - howFast) - rectangles[2].X) / howFast;

            //if (rectangles[1].X > rectangles[0].X + howFast)
            //    rectangles[1].X -= (rectangles[1].X - (rectangles[0].X + howFast)) / howFast;
            //else if (rectangles[1].X + howFast < rectangles[0].X)
            //    rectangles[1].X += ((rectangles[0].X - howFast) - rectangles[1].X) / howFast;

            //if (rectangles[3].Y > rectangles[2].Y + howFast)
            //    rectangles[3].Y -= (rectangles[3].Y - (rectangles[2].Y + howFast)) / howFast;
            //else if (rectangles[3].Y + howFast < rectangles[2].Y)
            //    rectangles[3].Y += ((rectangles[2].Y - howFast) - rectangles[3].Y) / howFast;

            //if (rectangles[2].Y > rectangles[1].Y + howFast)
            //    rectangles[2].Y -= (rectangles[2].Y - (rectangles[1].Y + howFast)) / howFast;
            //else if (rectangles[2].Y + howFast < rectangles[1].Y)
            //    rectangles[2].Y += ((rectangles[1].Y - howFast) - rectangles[2].Y) / howFast;

            //if (rectangles[1].Y > rectangles[0].Y + howFast)
            //    rectangles[1].Y -= (rectangles[1].Y - (rectangles[0].Y + howFast)) / howFast;
            //else if (rectangles[1].Y + howFast < rectangles[0].Y)
            //    rectangles[1].Y += ((rectangles[0].Y - howFast) - rectangles[1].Y) / howFast;
        }
        

        public Rectangle getPos()
        {
            return rectangles[0];
        }

        public bool Intersects(Rectangle r)
        {
            if (r.Intersects(rectangles[0]))
                return true;
            return false;
        }

        public string Intersects(Dictionary<string, Building> buildings, map currentMap)
        {
            string what="";
            foreach (KeyValuePair<string, Building> kvp in buildings)
            {
                switch (kvp.Key)
                {
                    case "1": if (currentMap != map.ConShop) { what = "!"; } break;
                    case "2": if (currentMap != map.EquiShop) { what = "!"; } break;
                    case "3":
                    case "h": if (currentMap != map.Hospital) { what = "!"; } break;
                    case "4":
                    case "i": if (currentMap != map.Inn) { what = "!"; } break;
                    case "5":
                    case "b": if (currentMap != map.Bank) { what = "!"; } break;
                    default: break;
                }
                if (currentMap == map.Town && (kvp.Value.getPos().Intersects(rectangles[0]) && kvp.Value.getDoor().Intersects(rectangles[0])))
                    return kvp.Key;
                if (currentMap != map.Town && currentMap != map.Wild1 && currentMap != map.Wild2 && currentMap != map.Wild3 && (kvp.Value.Intersects(this) && kvp.Value.getDoor().Intersects(rectangles[0], true, true)))//adds true when intersecting door bc door can be halfway into player and for leaving place
                {
                    switch (kvp.Key)
                    {
                        case "1": if (currentMap == map.ConShop) { return kvp.Key; } break;
                        case "2": if (currentMap == map.EquiShop) { return kvp.Key; } break;
                        case "3":
                        case "h": if (currentMap == map.Hospital) { return kvp.Key; } break;
                        case "4":
                        case "i": if (currentMap == map.Inn) { return kvp.Key; } break;
                        case "5":
                        case "b": if (currentMap == map.Bank) { return kvp.Key; } break;
                        default: return "0";
                    }
                }
                else if((currentMap == map.Town || currentMap == map.Wild1 || currentMap == map.Wild2 || currentMap == map.Wild3) && kvp.Value.getPos().Intersects(rectangles[0]) || (currentMap != map.Town && currentMap != map.Wild1 && currentMap != map.Wild2 && currentMap != map.Wild3 && (!kvp.Value.Intersects(rectangles[0])) && (!kvp.Value.getDoor().Intersects(rectangles[0], true)) && what!="!"))
                {
                    return "0";
                }

                if (what == "!")
                    what = "";
                
            }
            if(what!="!")
            return what;
            return "";
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.Draw(texture, rectangles[3], sourceRectangles[3], Color.White);
            spriteBatch.Draw(texture, rectangles[2], sourceRectangles[2], Color.White);
            spriteBatch.Draw(texture, rectangles[1], sourceRectangles[1], Color.White);
            spriteBatch.Draw(texture, rectangles[0], sourceRectangles[0], Color.White);
        }


    }
}
