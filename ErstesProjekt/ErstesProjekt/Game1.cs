using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ErstesProjekt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 direction = new Vector2(100f, 100f);
        // Mausstatus merken um eine Änderung festzustellen
        MouseState originalMouseState = Mouse.GetState();

        Texture2D star;

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

            // TODO: use this.Content to load your game content here
            star = Content.Load<Texture2D>("starGold");
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
            // Aktuellen Mausstatus merken
            MouseState currentMouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) direction += new Vector2(-1f, 0f);
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) direction += new Vector2(1f, 0f);
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) direction += new Vector2(0f, -1f);
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) direction += new Vector2(0f, 1f);

            // Wenn der Mausstatus sich im Vergleich zum alten Status geändert hat dann setze die Position neu
            if (currentMouseState != originalMouseState)
                direction = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            base.Update(gameTime);
            // Aktuellerstatus wird als original Status gemerkt.
            originalMouseState = currentMouseState;
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
            spriteBatch.Draw(star, direction, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
