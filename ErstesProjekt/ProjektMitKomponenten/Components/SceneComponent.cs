using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMitKomponenten.Components
{
    /*
     * Komponente die für das Rendern der Grafik zuständig ist
     */
    internal class SceneComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D star;
        private Game1 game;

        public SceneComponent(Game1 game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            star = Game.Content.Load<Texture2D>("starGold");
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(star, game.Simulation.Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
