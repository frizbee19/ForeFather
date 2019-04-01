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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tile[,] tiles = new Tile[16, 16];
        Rectangle[] tileSource = new Rectangle[4];
        Texture2D spritesheet;

        Texture2D bank;
        Texture2D hospital;
        Texture2D inn;
        Texture2D tilesSheet;

        Dictionary<string, Building> buildings = new Dictionary<string, Building>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            tileSource[0] = new Rectangle(0, 0, 50, 50); // grass
            tileSource[1] = new Rectangle(50, 0, 50, 50); // flowers
            tileSource[2] = new Rectangle(100, 0, 50, 50); // street
            tileSource[3] = new Rectangle(150, 0, 50, 50); // wood

            this.Window.AllowUserResizing = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
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

            bank = Content.Load<Texture2D>("Assets\\Bank");
            hospital = Content.Load<Texture2D>("Assets\\Hospital");
            inn = Content.Load<Texture2D>("Assets\\Inn");
            tilesSheet = Content.Load<Texture2D>("Assets\\Tiles");
            // TODO: use this.Content to load your game content here
            ReadFile(@"Content\\Assets\\TownText.txt");
        }

        public void ReadFile(string path)
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
                                case "-": tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50*i, 50*j, 50, 50), false); break;
                                case "g": tiles[j, i] = new Tile(tilesSheet, tileSource[0], new Rectangle(50 * i, 50 * j, 50, 50), true); break;
                                case "f": tiles[j, i] = new Tile(tilesSheet, tileSource[1], new Rectangle(50 * i, 50 * j, 50, 50), true); break;
                                case "s": tiles[j, i] = new Tile(tilesSheet, tileSource[2], new Rectangle(50 * i, 50 * j, 50, 50), true); break;

                                    //These will also make a building
                                case "1":
                                    tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false);
                                    if (!buildings.ContainsKey("1"))
                                        buildings.Add("1", new Building(inn, i*50, j*50));//replace to add consumableShop
                                    else
                                        buildings["1"].setSize(j, i);
                                    break;
                                case "2":
                                    tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;
                                case "i":
                                    tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;
                                case "b":
                                    tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;
                                case "h":
                                    tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;

                                default: tiles[j, i] = new Tile(tilesSheet, tileSource[3], new Rectangle(50 * i, 50 * j, 50, 50), false); break;
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
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    tiles[i, j].Draw(spriteBatch);
                }
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
