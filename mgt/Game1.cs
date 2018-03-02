using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mgt.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        SmoothFramerate smoothFPS = new SmoothFramerate(1000);//init fps counter
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Manager manager;
        World world;

        //shaders
        Effect effect;
        Effect greyscale;

        private Texture2D test;
        private SpriteFont font;

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

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            manager = new Manager(spriteBatch);
            world = manager.newWorld();


            //resize window
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            //IsFixedTimeStep = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            test = Content.Load<Texture2D>("download");

            //load shaders
            effect = Content.Load<Effect>("shader");
            greyscale = Content.Load<Effect>("greyscale");

            manager.newObj(new Shuttle());




            font = Content.Load<SpriteFont>("font2");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            KeyboardState state = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                Exit();

            manager.update(); //update manager-tracked objects

            //create a texture2d from an Obj's path variable. highly useful because 
            //it means i don't need to write lines of code to load every sprite
            for (int i = 0; i < manager.world.contents.Length; i++)
            { 
                if (manager.world.contents[i] != null)
                { //would put this in Manager but it can't access the content manager
                    if (manager.world.contents[i].sprite == null) //ez performance optimization
                    {
                        manager.world.contents[i].sprite = Content.Load<Texture2D>(manager.world.contents[i].path);
                        Console.WriteLine("resolved sprite");
                    }
                }
            }



            smoothFPS.Update(gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            //effect.Parameters["texMask"].SetValue(Content.Load<Texture2D>("rainbow"));
            //effect.CurrentTechnique.Passes[0].Apply(); //apply shader

            spriteBatch.Draw(test, new Rectangle(0, 0, 1920, 1200), Color.White);
            manager.draw(); //draw objects tracked by the manager
            spriteBatch.DrawString(font, "FPS: "+smoothFPS.framerate.ToString("0000"), new Vector2(0, 0), Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
