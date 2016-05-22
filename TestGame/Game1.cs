using Aditum;
using Aditum.BaseElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen TestScreen;

        KeyboardState PreviousStateKey;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //contain.
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

            // we create our screen
            TestScreen = new Screen(Content.ServiceProvider);

            // add a container to add elements to
            // we pass back a ref to we can mod it out side of the screen
            IContainer contain = TestScreen.AddContainer("test");

            // we add an element and once again pass a ref so we can mod the element
            // we also set the siblings right after creation
            GuiElement testElement = contain.AddElement(new TestElement(1)
                .Siblings(2,2,0,0));
            GuiElement testElement2 = contain.AddElement(new TestElement(2)
                .Siblings(1, 1, 0, 0).RealtivePOS(0, 50));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A) && !PreviousStateKey.IsKeyDown(Keys.A))
            {
                // when we want to interact with a control from either in the screen our outside of the screen stack
                // we call GetElement and return a ref
                GuiElement tempEle = TestScreen.GetElement("Test");
                if (tempEle.Visable == true)
                {
                    tempEle.Visable = false;
                }
                else
                {
                    tempEle.Visable = true;
                }
            }


            PreviousStateKey = Keyboard.GetState();
            TestScreen.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch batch = new SpriteBatch(GraphicsDevice);
            batch.Begin();
            TestScreen.Draw(batch, gameTime);
            batch.End();

            base.Draw(gameTime);
        }
    }
}
