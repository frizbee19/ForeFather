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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public  enum map {Town, Wild, ConShop, EquiShop, Bank, Hospital, Inn, Mountain, Combat};
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Tile[,]> maps;

        public static map currentMap;

        Rectangle[] tileSource;
        Texture2D spritesheet;

        Texture2D blank;
        SpriteFont spriteFont;
        Combat combat;
        KeyboardState kb;
        KeyboardState oldkb;

        Ally Ally1;

        Ally Ally2;

        Ally Ally3;
        
        Ally Ally4;

        Enemy testEnemy;
        List<Ally> allies;
        List<Enemy> enemies;

        Player p1;




        Texture2D bank;
        Texture2D hospital;
        Texture2D inn;
        Texture2D tilesSheet;
        Texture2D consume;
        Texture2D equip;

        Dictionary<string, Building> buildings;
        Dictionary<string, Building> insideBuilds;

        Rectangle startRect = new Rectangle(420, 10, 0, 0);

        Rectangle blankRect;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tileSource = new Rectangle[4];
            IsMouseVisible = true;
            p1 = new Player(Content, startRect, 1, 1);

            Ally1 = new Ally("Arlo", 10, 10, 10, 10, 10);

            Ally2 = new Ally("Hunter", 10, 10, 10, 10, 10);
            Ally3 = new Ally("Jac-E", 10, 10, 10, 10, 10);
            Ally4 = new Ally("Noire", 10, 10, 10, 10, 10);

            testEnemy = new Enemy("enemy1", 40, 10, 10, 10, 10);
            

            allies = new List<Ally>() { Ally1, Ally2, Ally3, Ally4 };
            enemies = new List<Enemy>() { testEnemy };
            combat = new Combat(this.Content, allies, enemies, this);

            tileSource[0] = new Rectangle(0, 0, 50, 50); // grass
            tileSource[1] = new Rectangle(50, 0, 50, 50); // flowers
            tileSource[2] = new Rectangle(100, 0, 50, 50); // street
            tileSource[3] = new Rectangle(150, 0, 50, 50); // wood

            this.Window.AllowUserResizing = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();


            buildings = new Dictionary<string, Building>();
            insideBuilds = new Dictionary<string, Building>();

            maps = new List<Tile[,]>();
            maps.Add(new Tile[16, 16]);
            maps.Add(new Tile[16, 16]);


            currentMap = map.Town;//Later, change this to begin in the wilderness
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

            combat.loadContent(this.Content, spriteFont, spriteBatch);


            bank = Content.Load<Texture2D>("Assets\\Bank");
            hospital = Content.Load<Texture2D>("Assets\\Hospital");
            inn = Content.Load<Texture2D>("Assets\\Inn");
            tilesSheet = Content.Load<Texture2D>("Assets\\Tiles");
            blank = Content.Load<Texture2D>("blank");
            consume = Content.Load<Texture2D>("Assets\\Consumable");
            equip = Content.Load<Texture2D>("Assets\\Equipable");
            // TODO: use this.Content to load your game content here
            ReadFile(@"Content\\Assets\\TownText.txt", 0);
            ReadFile(@"Content\\Assets\\ConsumableText.txt", 1);
        }

        public void ReadFile(string path, int numInList)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int j = 0;//j is column
                while (!reader.EndOfStream)
                {
                    string hmm = reader.ReadLine();

                    if (!hmm.Contains("//") && !hmm.Equals(""))
                    {
                        string[] charInput = hmm.Split();
                        for (int i = 0; i < charInput.Length; i++)//i also applies as row
                        {
                            switch (charInput[i])
                            {
                                case "-": maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;
                                case "?": maps.ElementAt(numInList)[j, i] = new Tile(blank, tileSource[0], new Rectangle(50 * i, 50 * j, 50, 50), false, Color.Black); break;
                                case "g": maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[0], new Rectangle(50 * i, 50 * j, 50, 50), true); break;
                                case "f": maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[1], new Rectangle(50 * i, 50 * j, 50, 50), true); break;
                                case "s": maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[2], new Rectangle(50 * i, 50 * j, 50, 50), true); break;
                                case "t":
                                    maps.ElementAt(numInList)[j, i] = new Tile(blank, tileSource[0], new Rectangle(50 * i, 50 * j, 50, 50), true);
                                    //insideBuilds.Add("" + numInList, new Building(new Rectangle(0, 0, 800, 800)));
                                    //if(!insideBuilds["" + numInList].hasDoor())
                                    //insideBuilds["" + numInList].setDoor(new Door(blank, new Rectangle(i * 50, j * 50, 50, 50)));
                                    //else
                                    //{

                                    //}
                                    break;

                                //These will also make a building
                                case "1":               
                                    maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false);
                                    if (!buildings.ContainsKey("1"))
                                        buildings.Add("1", new Building(consume, i * 50, j * 50));//replace to add consumableShop
                                    else if (!buildings["1"].hasDoor())
                                    {
                                        maps.ElementAt(numInList)[j, i].setWalk(true);
                                        buildings["1"].setDoor(new Door(blank, new Rectangle(i * 50 - 5, j * 50 - 3, 60, 53)));
                                    }
                                    else
                                        buildings["1"].setSize((i + 1) * 50, (j + 1) * 50);
                                    break;
                                case "2":
                                    maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false);
                                    if (!buildings.ContainsKey("2"))
                                        buildings.Add("2", new Building(equip, i * 50, j * 50));//replace to add equippableShop
                                    else if (!buildings["2"].hasDoor())
                                    {
                                        maps.ElementAt(numInList)[j, i].setWalk(true);
                                        buildings["2"].setDoor(new Door(blank, new Rectangle(i * 50 - 5, j * 50 - 3, 60, 53)));
                                    }
                                    else
                                        buildings["2"].setSize((i + 1) * 50, (j + 1) * 50);
                                    break;
                                case "i":
                                    maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false);
                                    if (!buildings.ContainsKey("i"))
                                        buildings.Add("i", new Building(inn, i * 50, j * 50));
                                    else if (!buildings["i"].hasDoor())
                                    {
                                        maps.ElementAt(numInList)[j, i].setWalk(true);
                                        buildings["i"].setDoor(new Door(blank, new Rectangle(i * 50 - 5, j * 50 - 3, 60, 53)));
                                    }
                                    else
                                        buildings["i"].setSize((i + 1) * 50, (j + 1) * 50);
                                    break;
                                case "b":
                                    maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false);
                                    if (!buildings.ContainsKey("b"))
                                        buildings.Add("b", new Building(bank, i * 50, j * 50));
                                    else if (!buildings["b"].hasDoor())
                                    {
                                        maps.ElementAt(numInList)[j, i].setWalk(true);
                                        buildings["b"].setDoor(new Door(blank, new Rectangle(i * 50 - 5, j * 50 - 3, 60, 53)));
                                    }
                                    else
                                        buildings["b"].setSize((i + 1) * 50, (j + 1) * 50);
                                    break;
                                case "h":
                                    maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false);
                                    if (!buildings.ContainsKey("h"))
                                        buildings.Add("h", new Building(hospital, i * 50, j * 50));
                                    else if (!buildings["h"].hasDoor())
                                    {
                                        maps.ElementAt(numInList)[j, i].setWalk(true);
                                        buildings["h"].setDoor(new Door(blank, new Rectangle(i * 50-5, j * 50-3, 60, 53)));
                                    }
                                    else
                                        buildings["h"].setSize((i + 1) * 50, (j + 1) * 50);
                                    break;

                                default: maps.ElementAt(numInList)[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;
                            }
                        }
                        j++;
                    }


                }
            }
        

        
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here


            kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.F8) && !oldkb.IsKeyDown(Keys.F8))
            {
                currentMap = map.Combat;
            }

            if (kb.IsKeyDown(Keys.Space) && !oldkb.IsKeyDown(Keys.Space))
            {
                switch (currentMap)
                {

                    case map.Town:
                        {
                            string whatBuild = p1.Intersects(buildings);
                            switch (whatBuild)
                            {
                                case "1": currentMap = map.ConShop; p1.setCoords(buildings["1"].getDoor().getPos().X, buildings["1"].getDoor().getPos().Y); break;
                                case "2": currentMap = map.EquiShop; break;
                                case "i": currentMap = map.Inn; break;
                                case "b": currentMap = map.Bank; break;
                                case "h": currentMap = map.Hospital; break;

                                default: break;
                            }
                            break;
                        }
                    default:
                        {
                            string whatBuild = p1.Intersects(insideBuilds);
                            switch (whatBuild)
                            {
                                case "1": currentMap = map.ConShop; p1.setCoords(buildings["1"].getDoor().getPos().X, buildings["1"].getDoor().getPos().Y);  break;
                                case "2": currentMap = map.EquiShop; break;
                                case "i": currentMap = map.Inn; break;
                                case "b": currentMap = map.Bank; break;
                                case "h": currentMap = map.Hospital; break;

                                default: break;
                            }
                            break;
                        }
                        break;
                }         
            }

            if (currentMap == map.Combat)
            {
                combat.update(kb, oldkb);
            }

            if (currentMap != map.Combat)
            {
                p1.update(buildings, currentMap);
            }

            oldkb = kb;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (currentMap)
            {
                case map.Town:
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            maps.ElementAt(0)[j, i].Draw(spriteBatch);
                        }
                    }

                    foreach (KeyValuePair<string, Building> kvp in buildings)
                    {
                        kvp.Value.Draw(spriteBatch, p1);//check if player intersects door, then give white if intersecting, else go black
                    }

                    p1.Draw(spriteBatch);

                    break;

                case map.Combat:
                    {
                        
                        combat.draw();
                    }
                    break;

                case map.ConShop:
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            maps.ElementAt(1)[j, i].Draw(spriteBatch);
                        }
                    }
                    break;

                default: break;
            } 
         



            
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
